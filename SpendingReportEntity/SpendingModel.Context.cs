﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpendingReportEntity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SpendingContext : DbContext
    {
        public SpendingContext()
            : base("name=SpendingContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<AmountInfo> AmountInfos { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Purpose> Purposes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
    }
}
