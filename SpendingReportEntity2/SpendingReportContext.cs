namespace SpendingReportEntity2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SpendingReportContext : DbContext
    {
        public SpendingReportContext()
            : base("name=SpendingContext")
        {
        }

        public virtual DbSet<AmountInfo> AmountInfos { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Purpos> Purposes { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmountInfo>()
                .Property(e => e.Amount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<AmountInfo>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.AmountInfo)
                .HasForeignKey(e => e.AmountInfo_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Purposes)
                .WithMany(e => e.Entries)
                .Map(m => m.ToTable("PurposeEntry").MapLeftKey("Entries_EntryId").MapRightKey("Purposes_Id"));

            modelBuilder.Entity<Type>()
                .HasMany(e => e.AmountInfos)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BankAccounts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
