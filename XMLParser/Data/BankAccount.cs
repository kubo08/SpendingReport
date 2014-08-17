
using System.Collections.Generic;
using XmlObjects;

namespace XMLParser.Data
{
    public class BankAccount
    {
        private List<Payment> _payments = new List<Payment>(); 

        #region Properties

        //public ulong? AccountNumber { get; set; }
        //public int? BankNumber { get; set; }
        //public ushort? BankID { get; set; }
        public ulong? AccountID { get; set; }
        public string IBan { get; set; }
        public Bank Bank { get; set; }
        public List<Payment> Payments {
            get { return _payments; }
            set { _payments = value; }
        } 

        #endregion

        public BankAccount( ulong? accountID, string iBan)
        {
            //BankID = bankID;
            AccountID = accountID;
            IBan = iBan;
        }

        public BankAccount()
        {
        }

    }
}