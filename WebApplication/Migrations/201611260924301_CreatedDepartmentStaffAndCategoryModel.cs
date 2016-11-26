namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDepartmentStaffAndCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 255),
                        Lastname = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Department_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            AddColumn("dbo.Archives", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Archives", "Category_Id", c => c.Byte());
            CreateIndex("dbo.Archives", "Category_Id");
            AddForeignKey("dbo.Archives", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Archives", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Staffs", new[] { "Department_Id" });
            DropIndex("dbo.Archives", new[] { "Category_Id" });
            DropColumn("dbo.Archives", "Category_Id");
            DropColumn("dbo.Archives", "CategoryId");
            DropTable("dbo.Staffs");
            DropTable("dbo.Departments");
            DropTable("dbo.Categories");
        }
    }
}
