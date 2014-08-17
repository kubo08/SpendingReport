using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Helpers;
using XMLParser.Data;
using XmlObjects;
using System.Xml;
using System.Xml.Serialization;

namespace XMLParser
{
    public partial class TBParser : IParser
    {

        #region Properties

        private readonly OFX _report;


        #endregion

        #region Constructor

        private readonly BankAccount _currentBankAccount;
        public TBParser(OFX report)
        {
            _report = report;
            _currentBankAccount = GetCurrentBankAccount(report);
        }

        #endregion

        //#region Public Methods

        public IEnumerable<Payment> ParseXML()
        {
            return _report.STMTRS.BANKTRANLIST.STMTTRN.Select(ProcessTransaction).ToList();
        }

        private Payment ProcessTransaction(OFXSTMTRSBANKTRANLISTSTMTTRN xmlTransaction)
        {
            Payment transaction = new Payment
            {
                TransactionAmount =
                    new AmountInfo(xmlTransaction.TRNAMT, xmlTransaction.CURRENCY.Trim(),
                        String.Equals(xmlTransaction.TRNTYPE.Trim(), "CREDIT", StringComparison.CurrentCultureIgnoreCase)
                            ? AmountType.Credit
                            : AmountType.Debit),
                BankAccount = SetBankAccount(xmlTransaction.BANKACCTTO),
                Description = xmlTransaction.MEMO,
                TransactionName = xmlTransaction.NAME,
                DateAvailable = GetDate(xmlTransaction.DTAVAIL.ToString(CultureInfo.InvariantCulture)),
                DatePosted = GetDate(xmlTransaction.DTPOSTED.ToString(CultureInfo.InvariantCulture)),
                Reference = xmlTransaction.REFERENCE_E2E,

            };
            return transaction;
        }

        public BankAccount SetBankAccount(OFXSTMTRSBANKTRANLISTSTMTTRNBANKACCTTO bankAccount)
        {
            return new BankAccount( bankAccount.ACCTID, bankAccount.IBAN);

        }

        /// <summary>
        /// Gets the payments.
        /// </summary>
        /// <returns></returns>
        public BankAccount GetBankAccountWithNewPayments()
        {
            List<Payment> payments = _report.STMTRS.BANKTRANLIST.STMTTRN.Select(transaction => new Payment
            {
                DateAvailable = GetDate(transaction.DTAVAIL.ToString(CultureInfo.InvariantCulture)), DatePosted = GetDate(transaction.DTPOSTED.ToString(CultureInfo.InvariantCulture)), ConstantSymbol = (short) transaction.TRNCOSYM, VariableSymbol = (long) transaction.TRNVASYM, SpecificSymbol = (long) transaction.TRNSPSYM, Reference = transaction.REFERENCE_E2E, TransactionName = transaction.NAME, Description = transaction.MEMO, TransactionAmount = new AmountInfo
                {
                    Type = transaction.TRNTYPE.Trim().ToLower() == "credit" ? AmountType.Credit : AmountType.Debit, Currency = transaction.CURRENCY, Amount = transaction.TRNAMT
                },
                BankAccount = new BankAccount
                {
                    AccountID = transaction.BANKACCTTO.ACCTID, IBan = transaction.BANKACCTTO.IBAN,
                    Bank = new Bank
                    {
                        BankID = transaction.BANKACCTTO.BANKID
                    }
                }
            }).ToList();

            _currentBankAccount.Payments.AddRange(payments);

            return _currentBankAccount;
        }

        #region Helper Methods

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private DateTime GetDate(string date)
        {
            var year = date.Trim().Substring(0, 4);
            var month = date.Trim().Substring(4, 2);
            var day = date.Trim().Substring(6);
            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        }

        /// <summary>
        /// Gets the current bank account, from which payments is processed.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns></returns>
        private BankAccount GetCurrentBankAccount(OFX report)
        {
            //Bank bank = new Bank
            //{
            //    Name = Bank.bank.TatraBanka,
            //    BankID=report.STMTRS.BANKACCTFROM.BANKID,
            //    Account = new BankAccount
            //    {
            //        AccountID = report.STMTRS.BANKACCTFROM.ACCTID,
            //        //BankID = report.STMTRS.BANKACCTFROM.BANKID,
            //        IBan = report.STMTRS.BANKACCTFROM.IBAN
            //    }
            //};

            BankAccount account = new BankAccount
            {
                AccountID = report.STMTRS.BANKACCTFROM.ACCTID,
                IBan = report.STMTRS.BANKACCTFROM.IBAN,
                Bank = new Bank
                {
                    Name = Bank.bank.TatraBanka,
                    BankID = report.STMTRS.BANKACCTFROM.BANKID
                }
            };
            return account;
        }

        #endregion

    }
}