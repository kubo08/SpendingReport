namespace SpendingReportEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accounts : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Entries", name: "BankAccountId", newName: "SourceAccountId");
            RenameIndex(table: "dbo.Entries", name: "IX_BankAccountId", newName: "IX_SourceAccountId");
            AddColumn("dbo.Entries", "DestinationAccountId", c => c.Int());
            CreateIndex("dbo.Entries", "DestinationAccountId");
            AddForeignKey("dbo.Entries", "DestinationAccountId", "dbo.BankAccounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "DestinationAccountId", "dbo.BankAccounts");
            DropIndex("dbo.Entries", new[] { "DestinationAccountId" });
            DropColumn("dbo.Entries", "DestinationAccountId");
            RenameIndex(table: "dbo.Entries", name: "IX_SourceAccountId", newName: "IX_BankAccountId");
            RenameColumn(table: "dbo.Entries", name: "SourceAccountId", newName: "BankAccountId");
        }
    }
}
