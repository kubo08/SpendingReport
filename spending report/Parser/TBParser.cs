//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI.WebControls;
//using Helpers;
//using spending_report.Data;
//using XmlObjects;
//using System.Xml;
//using System.Xml.Serialization;

//namespace spending_report.Parser
//{
//    public partial class TBParser<T> : IParser<T> where T : class
//    {

//        #region Properties

//        private T _report;

//        private IEnumerable<Payment> _payments;

//        #endregion

//        #region Constructor

//        public TBParser(T report)
//        {
//            _report = report;
//        }

//        #endregion

//        //#region Public Methods

//        public IEnumerable<Payment> GetPaymentsFromReport(string report)
//        {


//            return _payments;
//        }

//        public IEnumerable<Payment> ParseXML(OFX xml)
//        {
//            return xml.STMTRS.BANKTRANLIST.STMTTRN.Select(ProcessTransaction).ToList();
//        }

//        private Payment ProcessTransaction(OFXSTMTRSBANKTRANLISTSTMTTRN xmlTransaction)
//        {
//            Payment transaction = new Payment
//            {
//                TransactionAmount =
//                    new AmountInfo(xmlTransaction.TRNAMT, xmlTransaction.CURRENCY.Trim(),
//                        String.Equals(xmlTransaction.TRNTYPE.Trim(), "CREDIT", StringComparison.CurrentCultureIgnoreCase)
//                            ? AmountType.Credit
//                            : AmountType.Debit),
//                BankAccount = SetBankAccount(xmlTransaction.BANKACCTTO),
//                Description = xmlTransaction.MEMO,
//                TransactionName = xmlTransaction.NAME,
//                DateAvailable =  GetDate(xmlTransaction.DTAVAIL),
//                DatePosted = GetDate(xmlTransaction.DTPOSTED),
//                Reference=xmlTransaction.REFERENCE_E2E,
                
//            };
//            return transaction;
//        }

//        public BankAccount SetBankAccount(OFXSTMTRSBANKTRANLISTSTMTTRNBANKACCTTO bankAccount)
//        {
//            return new BankAccount(bankAccount.BANKID, bankAccount.ACCTID, bankAccount.IBAN, bankAccount.BANKIDSpecified);

//        }

//        //public void ProcessReport(T report)
//        //{
//        //    //foreach(var transaction in report){

//        //    //}
//        //}


//        //#endregion

//        //#region Private Methods



//        //#endregion


//        //public void ParseReport()
//        //{
//        //    throw new NotImplementedException();
//        //}


//        public IEnumerable<Payment> ParseXML(T xml)
//        {
//            throw new NotImplementedException();
//        }

//        #region Helper Methods

//        private DateTime GetDate(uint date)
//        {
//            var year = int.Parse(date.ToString().Substring(0, 4));
//            var month = int.Parse(date.ToString().Substring(4, 2));
//            var day = int.Parse(date.ToString().Substring(6));

//            return new DateTime(year, month, day);
//            ;
//        }

//        #endregion

//    }
//}