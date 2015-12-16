using System.Configuration;

namespace SpendingReportEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Type
    {
        //public Type()
        //{
        //}

        //public int Id { get; set; }

        //[Required]
        //public string TypeName { get; set; }

        public Type()
        {
            this.Users = new HashSet<User>();
        }

        public virtual ICollection<User> Users { get; set; }
    }
}
