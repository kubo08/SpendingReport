using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLParser.Data
{
    public class BankAccountBase
    {

        #region Properties

        //public ulong? AccountNumber { get; set; }
        //public int? BankNumber { get; set; }
        //public ushort? BankID { get; set; }
        public long? AccountID { get; set; }
        public string IBan { get; set; }
        public Bank Bank { get; set; }


        #endregion

        internal BankAccountBase(ulong? accountID, string iBan, ushort? bankID)
        {
            //BankID = bankID;
            AccountID = (long?)accountID.Value;
            IBan = iBan;
            Bank = new Bank
            {
                BankID = bankID
            };
        }

        public BankAccountBase()
        {
        }
    }
}
