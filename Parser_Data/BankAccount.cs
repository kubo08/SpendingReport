using System.Collections.Generic;

namespace parser.Data
{
    public class BankAccount : BankAccountBase
    {
        public static BankAccount CreateBankAccount(ulong? accountID, string iBan, ushort? bankID)
        {
            return new BankAccount(accountID, iBan, bankID);
        }

        List<Payment> _payments = new List<Payment>();


        public List<Payment> Payments
        {
            get { return _payments; }
            set { _payments = value; }
        }


        private BankAccount(ulong? accountID, string iBan, ushort? bankID)
            : base(accountID, iBan, bankID)
        {
        }

        public BankAccount()
        {
        }

    }
}