namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [NameIdentifier], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'14920569-d272-4c07-9e5a-0f7511815739', N'SuperAdmin', N'admin@admin.com', 0, N'AEHWamJIwxglqzNbGZmIgXy6h52GaQPdmxi6o8Hj/wY+QGeKu8WlWziX4n7UFoAS9g==', N'3e418794-17d3-4185-bd3b-b1d06108e25d', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [NameIdentifier], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8404a049-f8e2-42e2-ac4c-76ce83568710', N'InfoTitan', N'profemzy@outlook.com', 0, N'AMd0WdkFZzxrxcjEP3S91wcaQfsVPlrl52F4mW8vzhaBPJHC35PllWjlJpu3hDkYOQ==', N'57cd6116-d67e-423d-b593-0a87108bd3c5', NULL, 0, 0, NULL, 1, 0, N'profemzy@outlook.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [NameIdentifier], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'859e07ea-19af-45fe-9295-c6f4c7529022', N'Oladele Femi', N'profemzy@gmail.com', 0, N'AO53pqgXpKGqrdG+ukz2Zw/6n+ZQK2DrV/24lo98FUpGD7f+r9B3P+Usn2MqE0CMvQ==', N'baf5b64c-1180-47f0-ab2b-f2bd6edda1b2', NULL, 0, 0, NULL, 1, 0, N'profemzy@gmail.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1d7e4728-91e7-4d28-86ca-c84dabae17fe', N'CanManageArchives')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14920569-d272-4c07-9e5a-0f7511815739', N'1d7e4728-91e7-4d28-86ca-c84dabae17fe')


                ");
        }
        
        public override void Down()
        {
        }
    }
}
