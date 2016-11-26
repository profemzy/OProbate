namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDtos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Staffs", new[] { "Department_Id" });
            DropColumn("dbo.Staffs", "DepartmentId");
            RenameColumn(table: "dbo.Staffs", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.Staffs", "DepartmentId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Staffs", "DepartmentId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Staffs", "DepartmentId");
            AddForeignKey("dbo.Staffs", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Staffs", new[] { "DepartmentId" });
            AlterColumn("dbo.Staffs", "DepartmentId", c => c.Byte());
            AlterColumn("dbo.Staffs", "DepartmentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Staffs", name: "DepartmentId", newName: "Department_Id");
            AddColumn("dbo.Staffs", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Staffs", "Department_Id");
            AddForeignKey("dbo.Staffs", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
