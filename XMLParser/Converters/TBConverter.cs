using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using XmlObjects;
using XMLParser.Data;

namespace XMLParser.Converters
{
    public static class TBConverter
    {

        public static Payment ObjectToModel(OFXSTMTRSBANKTRANLISTSTMTTRN xmlTransaction)
        {
            Payment transaction = new Payment
            {
                TransactionAmount =
                    new AmountInfo(xmlTransaction.TRNAMT, xmlTransaction.CURRENCY.Trim(),
                        String.Equals(xmlTransaction.TRNTYPE.Trim(), Constants.CREDIT, StringComparison.CurrentCultureIgnoreCase)
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

        public static Import ObcectToModel(OFX report)
        {
            var bankTransactions = new Import()
            {
                Account = new BankAccount
                {
                    AccountID = report.STMTRS.BANKACCTFROM.ACCTID,
                    IBan = report.STMTRS.BANKACCTFROM.IBAN,
                    Payments=new List<Payment>(),
                    Bank = new Bank
                    {
                        BankID = report.STMTRS.BANKACCTFROM.BANKID
                    }
                },
                From = GetDate(report.STMTRS.BANKTRANLIST.DTSTART.ToString(CultureInfo.InvariantCulture)),
                To = GetDate(report.STMTRS.BANKTRANLIST.DTEND.ToString(CultureInfo.InvariantCulture))
            };
            foreach (var trasaction in report.STMTRS.BANKTRANLIST.STMTTRN)
            {
              bankTransactions.Account.Payments.Add(ObjectToModel(trasaction));  
            }

            return bankTransactions;
        } 

        private static BankAccount SetBankAccount(OFXSTMTRSBANKTRANLISTSTMTTRNBANKACCTTO bankAccount)
        {
            return BankAccount.CreateBankAccount(bankAccount.ACCTID, bankAccount.IBAN, bankAccount.BANKID);
        }

        private static DateTime GetDate(string date)
        {
            var year = date.Trim().Substring(0, 4);
            var month = date.Trim().Substring(4, 2);
            var day = date.Trim().Substring(6);
            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        }
    }
}
