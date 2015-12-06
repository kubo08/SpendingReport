namespace SpendingReportEntity2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentType
    {
        public PaymentType()
        {
            Entries = new HashSet<Entry>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}