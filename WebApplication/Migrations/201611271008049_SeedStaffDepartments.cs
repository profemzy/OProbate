namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStaffDepartments : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                        INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (1, N'Personnel')
                        INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (2, N'Litigation')
                        INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (3, N'Finance and Accounts')
                        INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (4, N'Procurement')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
