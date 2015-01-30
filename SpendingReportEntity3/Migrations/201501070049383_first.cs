namespace SpendingReportEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmountInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 8, scale: 2),
                        Currency = c.String(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId)
                .Index(t => t.TypeId);

            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DatePosted = c.DateTime(),
                        Memo = c.String(),
                        DateAvailable = c.DateTime(),
                        VariableSymbol = c.Long(),
                        ConstantSymbol = c.Short(),
                        SpecificSymbol = c.Long(),
                        Reference = c.String(),
                        PaymentTypeId = c.Int(),
                        BankId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AmountInfo_Id = c.Int(nullable: false),
                        BankAccountID = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountID)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .ForeignKey("dbo.AmountInfos", t => t.AmountInfo_Id)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.AmountInfo_Id)
                .Index(t => t.BankAccountID);

            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Long(),
                        IBAN = c.String(),
                        Name = c.String(),
                        BankId = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.BankId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BankCode = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Purposes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PurposeEntry",
                c => new
                    {
                        Entries_EntryId = c.Int(nullable: false),
                        Purposes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Entries_EntryId, t.Purposes_Id })
                .ForeignKey("dbo.Entries", t => t.Entries_EntryId, cascadeDelete: true)
                .ForeignKey("dbo.Purposes", t => t.Purposes_Id, cascadeDelete: true)
                .Index(t => t.Entries_EntryId)
                .Index(t => t.Purposes_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AmountInfos", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Entries", "AmountInfo_Id", "dbo.AmountInfos");
            DropForeignKey("dbo.PurposeEntry", "Purposes_Id", "dbo.Purposes");
            DropForeignKey("dbo.PurposeEntry", "Entries_EntryId", "dbo.Entries");
            DropForeignKey("dbo.Entries", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.BankAccounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Entries", "BankAccountID", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks");
            DropIndex("dbo.PurposeEntry", new[] { "Purposes_Id" });
            DropIndex("dbo.PurposeEntry", new[] { "Entries_EntryId" });
            DropIndex("dbo.BankAccounts", new[] { "UserId" });
            DropIndex("dbo.BankAccounts", new[] { "BankId" });
            DropIndex("dbo.Entries", new[] { "BankAccountID" });
            DropIndex("dbo.Entries", new[] { "AmountInfo_Id" });
            DropIndex("dbo.Entries", new[] { "PaymentTypeId" });
            DropIndex("dbo.AmountInfos", new[] { "TypeId" });
            DropTable("dbo.PurposeEntry");
            DropTable("dbo.Types");
            DropTable("dbo.Purposes");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Banks");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.Entries");
            DropTable("dbo.AmountInfos");
        }
    }
}
