using System.Runtime.InteropServices;

namespace SpendingReportEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class userID_manual : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankAccounts", "UserID", c => c.Int(nullable: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.BankAccounts", "UserID", c => c.Int(nullable: false));
        }
    }
}
