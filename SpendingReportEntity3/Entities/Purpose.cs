namespace SpendingReportEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purposes")]
    public partial class Purpose
    {
        public Purpose()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
