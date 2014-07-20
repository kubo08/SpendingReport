using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using XmlObjects;
using SpendingReportEntity;
using XMLParser.Data;
using AmountInfo = SpendingReportEntity.AmountInfo;
using Bank = XMLParser.Data.Bank;
using BankAccount = SpendingReportEntity.BankAccount;

namespace Support
{
    public static class XMLHelpers
    {
        private const string TB = "Tatra Banka";

        public static string SaveFile(HttpFileCollectionBase Files,string path)
        {
            try
            {
                if (Files.Count > 0)
                {
                    var file = Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        path = Path.Combine(path, fileName);
                        file.SaveAs(path);
                    }
                }
                return path;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static int ReadXmlFile(string path)
        //{
        //    try
        //    {
        //        System.Xml.Serialization.XmlSerializer reader =
        //            new System.Xml.Serialization.XmlSerializer(typeof (OFX));
        //        StreamReader file = new StreamReader(path);

        //        var overview = (OFX) reader.Deserialize(file);
        //        file.Dispose();
        //        File.Delete(path);

        //        int count = ProcessPayments(overview.STMTRS.BANKTRANLIST);

        //        return count;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Processes the payments from Tatra Banka xml.
        /// </summary>
        /// <param name="transactionList">The transaction list.</param>
        /// <returns></returns>
        private static int ProcessPayments(OFXSTMTRSBANKTRANLIST transactionList)
        {
            int processed = 0;
            using (var context = new SpendingContext())
            {
                foreach (var transaction in transactionList.STMTTRN.Where(transaction => !IsTransactionExist(context, transaction)))
                {
                    SpendingReportEntity.Type amountType;
                    switch(transaction.TRNTYPE.ToLower().Trim())
                    {
                        case "debit":
                            amountType =
                                context.Types.FirstOrDefault(item => item.TypeName.ToLower().Trim() == "Debit".ToLower().Trim());
                            break;
                        case "credit":
                            amountType =
                                context.Types.FirstOrDefault(
                                    item => item.TypeName.ToLower().Trim() == "Credit".ToLower().Trim());
                            break;
                        default:
                            amountType =
                                context.Types.FirstOrDefault(
                                    item => item.TypeName.ToLower().Trim() == "Not defined".ToLower().Trim());
                            break;
                    }

                    AmountInfo amountInfo = new AmountInfo
                    {
                        Amount = Math.Abs(transaction.TRNAMT),
                        Currency = transaction.CURRENCY.Trim(),
                        Type = amountType
                    };

                    var bank = context.Banks.FirstOrDefault(item => item.Name.ToLower().Trim() == TB.ToLower().Trim());

                    BankAccount bankAccount= new BankAccount
                    {
                        AccountNumber = (long) transaction.BANKACCTTO.ACCTID,
                        //BankCode = (short) transaction.BANKACCTTO.BANKID,
                        IBAN = transaction.BANKACCTTO.IBAN
                    };

                    context.Entries.Add(new Entry
                    {
                        Bank = bank,
                        Name = transaction.NAME,
                        AmountInfo = amountInfo,
                        BankAccount = bankAccount,
                        Memo=transaction.MEMO,
                        ConstantSymbol = (short)transaction.TRNCOSYM,
                        VariableSymbol=(long)transaction.TRNVASYM,
                        SpecificSymbol = (long)transaction.TRNSPSYM,
                        Reference = transaction.REFERENCE_E2E,
                        DatePosted = GetDate(transaction.DTPOSTED.ToString(CultureInfo.InvariantCulture)),
                        DateAvailable = GetDate(transaction.DTAVAIL.ToString(CultureInfo.InvariantCulture))

                    });
                    processed++;
                }
                context.SaveChanges();
            }
            return processed;
        }


        /// <summary>
        /// Checks if transaction allready exists in the database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        private static bool IsTransactionExist(SpendingContext context, OFXSTMTRSBANKTRANLISTSTMTTRN transaction)
        {
            var date = GetDate(transaction.DTAVAIL.ToString(CultureInfo.InvariantCulture));
            var tr = context.Entries.Where(t => t.Name == transaction.NAME).Include(x => x.AmountInfo);
            var item =
                context.Entries.Where(
                    t =>
                        t.AmountInfo.Amount == transaction.TRNAMT && t.Name == transaction.NAME &&
                        t.Memo == transaction.MEMO &&
                        t.DateAvailable == date);
            return item.Any();            
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private static DateTime GetDate(string date)
        {
            var year = date.Trim().Substring(0, 4);
            var month = date.Trim().Substring(4, 2);
            var day = date.Trim().Substring(6);
            return new DateTime(int.Parse(year),int.Parse(month),int.Parse(day));
        }

        public static IEnumerable<Payment> GetBankTransactions(short bankNumber)
        {
            using (var context = new SpendingContext())
            {
                var bank = context.Banks.FirstOrDefault(t => t.BankCode == bankNumber);

                return ((Bank) bank).Payments;
            }
        }

        private IEnumerable<Payment> FillBankTransactions(IEnumerable<Payment> transactions)
        {
            List<Payment> newTransactions=new List<Payment>();   
            foreach(var transaction in transactions)
            {
                var newTransaction = new Payment
                {
                    DateAvailable = transaction.DateAvailable,
                    ConstantSymbol = transaction.ConstantSymbol,
                    DatePosted = transaction.DatePosted,
                    Description = transaction.Description,
                    Reference=transaction.Reference,
                    SpecificSymbol=transaction.SpecificSymbol,
                    TransactionName=transaction.TransactionName,
                    VariableSymbol=transaction.VariableSymbol,
                    BankAccount=new XMLParser.Data.BankAccount
                    {
                        AccountID=transaction.BankAccount.AccountID,
                        IBan=transaction.BankAccount.IBan,
                        Bank=new Bank
                        {
                            Name = transaction.BankAccount.Bank.nam
                        }
                    }
                }
            }
        }
    }
}