namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bank
    {
        public Bank()
        {
            BankAccounts = new HashSet<BankAccount>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short BankCode { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
