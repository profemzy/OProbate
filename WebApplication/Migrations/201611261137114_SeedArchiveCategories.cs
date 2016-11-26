namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedArchiveCategories : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Criminal')
                    INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Divorce or Seperation')
                    INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Eviction Housing')
                    INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Traffic')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
