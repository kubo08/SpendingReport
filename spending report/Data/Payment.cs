//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace spending_report.Data
//{
//    public class Payment
//    {
//        #region private Properties

//        public AmountInfo TransactionAmount { get; set; }

//        public BankAccount BankAccount { get; set; }

//        public string Description { get; set; }

//        public DateTime? DatePosted { get; set; }

//        public DateTime? DateAvailable { get; set; }

//        public string TransactionName { get; set; }

//        public string Reference
//        {
//            get { return String.Format("/VS{0}/SS{1}/KS{2}", VariableSymbol, SpecificSymbol, ConstantSymbol); }

//            set
//            {
//                string[] symbols = value.Split('/');
//                VariableSymbol = symbols[0].Substring(2);
//                SpecificSymbol = symbols[1].Substring(2);
//                ConstantSymbol = symbols[2].Substring(2);
//            }
//        }

//        public string VariableSymbol { get; set; }

//        public string ConstantSymbol { get; set; }

//        public string SpecificSymbol { get; set; }

//        #endregion
//    }
//}