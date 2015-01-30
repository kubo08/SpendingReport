namespace SpendingReportEntity2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BankAccount
    {
        public int Id { get; set; }

        public long? AccountNumber { get; set; }

        public string IBAN { get; set; }

        public string Name { get; set; }

        public int? BankId { get; set; }

        public int UserId { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual User User { get; set; }
    }
}
