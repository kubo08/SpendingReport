namespace SpendingReportEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        //public User()
        //{
        //    BankAccounts = new HashSet<BankAccount>();
        //}

        //public int Id { get; set; }

        //public virtual ICollection<BankAccount> BankAccounts { get; set; }

        public User()
        {
            this.Types = new HashSet<Type>();
        }

        public virtual ICollection<Type> Types { get; set; }
    }
}
