namespace SpendingReportEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AmountInfos")]
    public partial class AmountInfo
    {
        public AmountInfo()
        {

        }

        public int Id { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        public int TypeId { get; set; }

        public virtual Type Type { get; set; }
    }
}
