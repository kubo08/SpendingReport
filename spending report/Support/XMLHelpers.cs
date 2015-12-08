using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
//using XmlObjects;
using XMLParser.Data;
using Bank = XMLParser.Data.Bank;
//using SpendingReportEntity.Converters;
using AmountType = XMLParser.Data.AmountType;

namespace Support
{
    public static class XMLHelpers
    {
        private const string TB = "Tatra Banka";

        public static string SaveFile(HttpFileCollectionBase Files, string path)
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

        ///// <summary>
        ///// Processes the payments from Tatra Banka xml.
        ///// </summary>
        ///// <param name="transactionList">The transaction list.</param>
        ///// <returns></returns>
        //public static Import ProcessPayments(Import transactionList)
        //{
        //    var ImportWithPocessedTransactions = new Import
        //    {
        //        Account = transactionList.Account,
        //        From = transactionList.From,
        //        To = transactionList.To,
        //        Transactions=new List<Payment>()
        //    };

        //    using (var context = new SpendingContext())
        //    {
        //        foreach (var transaction in transactionList.Transactions.Where(transaction => !IsTransactionExist(context, transaction)))
        //        {
        //            SpendingReportEntity.Type amountType;
        //            switch(transaction.TransactionAmount.Type)
        //            {
        //                case XMLParser.Data.AmountType.Debit:
        //                    amountType =
        //                        context.Types.FirstOrDefault(item => item.TypeName.ToLower().Trim() == "Debit".ToLower().Trim());
        //                    break;
        //                case XMLParser.Data.AmountType.Credit:
        //                    amountType =
        //                        context.Types.FirstOrDefault(
        //                            item => item.TypeName.ToLower().Trim() == "Credit".ToLower().Trim());
        //                    break;
        //                default:
        //                    amountType =
        //                        context.Types.FirstOrDefault(
        //                            item => item.TypeName.ToLower().Trim() == "Not defined".ToLower().Trim());
        //                    break;
        //            }

        //            AmountInfo amountInfo = new AmountInfo
        //            {
        //                Amount = Math.Abs(transaction.TransactionAmount.Amount),
        //                Currency = transaction.TransactionAmount.Currency.Trim(),
        //                Type = amountType
        //            };

        //            var bank = context.Banks.FirstOrDefault(item => item.Name.ToLower().Trim() == TB.ToLower().Trim());

        //            BankAccount bankAccount= new BankAccount
        //            {
        //                AccountNumber = transaction.BankAccount.AccountID,
        //                //BankCode = (short) transaction.BANKACCTTO.BANKID,
        //                IBAN = transaction.BankAccount.IBan
        //            };

        //            context.Entries.Add(new Entry
        //            {
        //                Bank = bank,
        //                Name = transaction.TransactionName,
        //                AmountInfo = amountInfo,
        //                BankAccount = bankAccount,
        //                Memo=transaction.Description,
        //                ConstantSymbol = transaction.ConstantSymbol,
        //                VariableSymbol=transaction.VariableSymbol,
        //                SpecificSymbol = transaction.SpecificSymbol,
        //                Reference = transaction.Reference,
        //                DatePosted = transaction.DatePosted,
        //                DateAvailable = transaction.DateAvailable

        //            });
        //            ImportWithPocessedTransactions.Transactions.Add(transaction);
        //        }
        //        context.SaveChanges();
        //    }
        //    return ImportWithPocessedTransactions;
        //}


        ///// <summary>
        ///// Checks if transaction allready exists in the database.
        ///// </summary>
        ///// <param name="context">The context.</param>
        ///// <param name="transaction">The transaction.</param>
        ///// <returns></returns>
        //private static bool IsTransactionExist(SpendingContext context, Payment transaction)
        //{
        //    var date = transaction.DateAvailable;
        //    var tr = context.Entries.Where(t => t.Name == transaction.TransactionName).Include(x => x.AmountInfo);
        //    var item =
        //        context.Entries.Where(
        //            t =>
        //                t.AmountInfo.Amount == transaction.TransactionAmount.Amount && t.Name == transaction.TransactionName &&
        //                t.Memo == transaction.Description &&
        //                t.DateAvailable == date);
        //    return item.Any();            
        //}

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
            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        }

        //public static IEnumerable<Payment> GetBankTransactions(short bankNumber)
        //{
        //    using (var context = new SpendingContext())
        //    {
        //        var bank = context.Banks.FirstOrDefault(t => t.BankCode == bankNumber);

        //        return bank != null ? FillBankTransactions(bank.Entries) : null;
        //    }
        //}

        //private static IEnumerable<Payment> FillBankTransactions(IEnumerable<SpendingReportEntity.Entry> transactions)
        //{
        //    return transactions.Select(transaction => new Payment
        //    {
        //        DateAvailable = transaction.DateAvailable,
        //        ConstantSymbol = transaction.ConstantSymbol.HasValue ? transaction.ConstantSymbol.Value : (short)0,
        //        DatePosted = transaction.DatePosted,
        //        Description = transaction.Memo,
        //        Reference = transaction.Reference,
        //        SpecificSymbol = transaction.SpecificSymbol.HasValue ? transaction.SpecificSymbol.Value : (long)0,
        //        TransactionName = transaction.Name,
        //        VariableSymbol = transaction.VariableSymbol.HasValue ? transaction.VariableSymbol.Value : (long)0,
        //        BankAccount = new XMLParser.Data.BankAccount
        //            {
        //                AccountID = transaction.DestinationAccount.AccountNumber.HasValue ? transaction.DestinationAccount.AccountNumber.Value : 0,
        //                IBan = transaction.DestinationAccount.IBAN,
        //                Bank = new Bank
        //                    {
        //                        //Name = transaction.BankAccount.BankId.HasValue ? ((Bank.bank?) transaction.BankAccount.BankId.Value) : null,
        //                        BankID = (ushort)transaction.DestinationAccount.Bank.BankCode
        //                    }
        //            },
        //        TransactionAmount = new XMLParser.Data.AmountInfo
        //        {
        //            Amount = transaction.AmountInfo.Amount,
        //            Currency = transaction.AmountInfo.Currency,
        //            Type = (AmountType)transaction.AmountInfo.TypeId
        //        },
        //        PaymentType = transaction.PaymentTypeId.HasValue ? (TypeOfPayment?)transaction.PaymentTypeId : null,
        //        //purpose = GetTransactionPurposes(transaction.ID)
        //    }).ToList();
        //}

        //private static List<string> GetTransactionPurposes(int id)
        //{
        //    using (var context = new spending())
        //    {
        //        var firstOrDefault = context.Entries.FirstOrDefault(t => t.ID == id);
        //        if (firstOrDefault != null)
        //            return firstOrDefault.Purposes.ToList().Select(t => t.Name).ToList();
        //    }
        //    return null;
        //}
    }
}