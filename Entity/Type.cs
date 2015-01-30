namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Type
    {
        public Type()
        {
            AmountInfos = new HashSet<AmountInfo>();
        }

        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<AmountInfo> AmountInfos { get; set; }
    }
}
