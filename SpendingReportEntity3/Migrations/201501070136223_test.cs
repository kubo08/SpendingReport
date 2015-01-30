namespace SpendingReportEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Entries", new[] { "BankAccountID" });
            CreateIndex("dbo.Entries", "BankAccountId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Entries", new[] { "BankAccountId" });
            CreateIndex("dbo.Entries", "BankAccountID");
        }
    }
}
