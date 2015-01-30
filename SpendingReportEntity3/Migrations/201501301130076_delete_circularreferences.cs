namespace SpendingReportEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_circularreferences : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurposeEntry", "Entries_EntryId", "dbo.Entries");
            DropForeignKey("dbo.PurposeEntry", "Purposes_Id", "dbo.Purposes");
            DropForeignKey("dbo.AmountInfos", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Entries", "AmountInfo_Id", "dbo.AmountInfos");
            DropIndex("dbo.Entries", new[] { "AmountInfo_Id" });
            DropIndex("dbo.PurposeEntry", new[] { "Entries_EntryId" });
            DropIndex("dbo.PurposeEntry", new[] { "Purposes_Id" });
            //CreateTable(
            //    "dbo.Purposes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Entry_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Entries", t => t.Entry_ID)
            //    .Index(t => t.Entry_ID);
            
            AddColumn("dbo.Entries", "AmountInfo_Id1", c => c.Int());
            CreateIndex("dbo.Entries", "AmountInfo_Id1");
            AddForeignKey("dbo.AmountInfos", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entries", "AmountInfo_Id1", "dbo.AmountInfos", "Id");
            DropTable("dbo.Purposes");
            DropTable("dbo.PurposeEntry");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurposeEntry",
                c => new
                    {
                        Entries_EntryId = c.Int(nullable: false),
                        Purposes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Entries_EntryId, t.Purposes_Id });
            
            CreateTable(
                "dbo.Purposes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Entries", "AmountInfo_Id1", "dbo.AmountInfos");
            DropForeignKey("dbo.AmountInfos", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Purposes", "Entry_ID", "dbo.Entries");
            DropIndex("dbo.Purposes", new[] { "Entry_ID" });
            DropIndex("dbo.Entries", new[] { "AmountInfo_Id1" });
            DropColumn("dbo.Entries", "AmountInfo_Id1");
            DropTable("dbo.Purposes");
            CreateIndex("dbo.PurposeEntry", "Purposes_Id");
            CreateIndex("dbo.PurposeEntry", "Entries_EntryId");
            CreateIndex("dbo.Entries", "AmountInfo_Id");
            AddForeignKey("dbo.Entries", "AmountInfo_Id", "dbo.AmountInfos", "Id");
            AddForeignKey("dbo.AmountInfos", "TypeId", "dbo.Types", "Id");
            AddForeignKey("dbo.PurposeEntry", "Purposes_Id", "dbo.Purposes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurposeEntry", "Entries_EntryId", "dbo.Entries", "ID", cascadeDelete: true);
        }
    }
}
