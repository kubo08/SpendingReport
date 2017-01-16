using System.Collections.Generic;

namespace parser.Data
{
    public class ImportedBankAccount : BankAccountBase
    {
        public static ImportedBankAccount CreateBankAccount(ulong? accountID, string iBan, ushort? bankID)
        {
            return new ImportedBankAccount(accountID, iBan, bankID);
        }


        public List<ImportedPayment> Payments { get; set; } = new List<ImportedPayment>();


        private ImportedBankAccount(ulong? accountID, string iBan, ushort? bankID)
            : base(accountID, iBan, bankID)
        {
        }

        public ImportedBankAccount()
        {
        }
    }
}
