namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedArchiveRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArchiveRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReqDate = c.DateTime(nullable: false),
                        Archive_Id = c.Int(nullable: false),
                        Staff_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Archives", t => t.Archive_Id, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.Staff_Id, cascadeDelete: true)
                .Index(t => t.Archive_Id)
                .Index(t => t.Staff_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArchiveRequests", "Staff_Id", "dbo.Staffs");
            DropForeignKey("dbo.ArchiveRequests", "Archive_Id", "dbo.Archives");
            DropIndex("dbo.ArchiveRequests", new[] { "Staff_Id" });
            DropIndex("dbo.ArchiveRequests", new[] { "Archive_Id" });
            DropTable("dbo.ArchiveRequests");
        }
    }
}
