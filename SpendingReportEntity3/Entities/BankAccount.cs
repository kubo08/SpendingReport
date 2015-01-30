namespace SpendingReportEntity
{
    using System.Collections.Generic;

    public partial class BankAccount
    {
        public BankAccount()
        {
            Entries = new HashSet<Entry>();
        }
        public int Id { get; set; }

        public long? AccountNumber { get; set; }

        public string IBAN { get; set; }

        public string Name { get; set; }

        public int? BankId { get; set; }

        public int? UserId { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
