
using System.Collections.Generic;
using XmlObjects;

namespace XMLParser.Data
{
    public class BankAccount
    {
        public static BankAccount CreateBankAccount(ulong? accountID, string iBan, ushort? bankID)
        {
            return new BankAccount(accountID, iBan, bankID);
        }

        #region Properties

        //public ulong? AccountNumber { get; set; }
        //public int? BankNumber { get; set; }
        //public ushort? BankID { get; set; }
        public long? AccountID { get; set; }
        public string IBan { get; set; }
        public Bank Bank { get; set; }
        public List<Payment> Payments {
            get { return _payments; }
            set { _payments = value; }
        } 

        #endregion

        private BankAccount( ulong? accountID, string iBan,ushort? bankID )
        {
            //BankID = bankID;
            AccountID = (long?) accountID.Value;
            IBan = iBan;
            Bank = new Bank
            {
                BankID = bankID
            };
        }

        public BankAccount()
        {
        }

    }
}