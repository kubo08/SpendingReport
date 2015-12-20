using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLParser.Data
{
    public class ImportedBankAccount : BankAccountBase
    {
        public static ImportedBankAccount CreateBankAccount(ulong? accountID, string iBan, ushort? bankID)
        {
            return new ImportedBankAccount(accountID, iBan, bankID);
        }

        List<ImportedPayment> _payments = new List<ImportedPayment>();


        public List<ImportedPayment> Payments
        {
            get { return _payments; }
            set { _payments = value; }
        }


        private ImportedBankAccount(ulong? accountID, string iBan, ushort? bankID)
            : base(accountID, iBan, bankID)
        {
        }

        public ImportedBankAccount()
        {
        }
    }
}
