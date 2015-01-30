namespace SpendingReportEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class repairDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "AmountInfo_Id", "dbo.AmountInfos");
            DropIndex("dbo.Entries", new[] { "AmountInfo_Id" });
            RenameColumn(table: "dbo.Entries", name: "AmountInfo_Id", newName: "AmountInfoId");
            AlterColumn("dbo.Entries", "AmountInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entries", "AmountInfoId");
            AddForeignKey("dbo.Entries", "AmountInfoId", "dbo.AmountInfos", "Id", cascadeDelete: true);
            DropColumn("dbo.Entries", "AmountInfo_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Entries", "AmountInfo_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Entries", "AmountInfoId", "dbo.AmountInfos");
            DropIndex("dbo.Entries", new[] { "AmountInfoId" });
            AlterColumn("dbo.Entries", "AmountInfoId", c => c.Int());
            RenameColumn(table: "dbo.Entries", name: "AmountInfoId", newName: "AmountInfo_Id");
            CreateIndex("dbo.Entries", "AmountInfo_Id");
            AddForeignKey("dbo.Entries", "AmountInfo_Id", "dbo.AmountInfos", "Id");
        }
    }
}
