namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'40f3b3e2-1f6e-4fa2-9428-1d0502c1384f', N'guest@guest.com', 0, N'AIM6vPvZd4Sfr9PuTaShdsnua58rNsxisFE4f7zd8XXumjSdNF0GXk4XMl3zBqWr9w==', N'abdf2348-4ca8-46c7-9b38-9547398877c8', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b32828a6-d631-44ab-8299-2bea39e2f02f', N'admin@admin.com', 0, N'APrLDPEmpG6pI6UCDM+n8R05pj+RfeR4tfU5GYV8g6zM+Ct9KDIuTPRzgjzfp2e6Fw==', N'be0f0a5b-2f16-4537-8fa5-685daec44b46', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'63f40459-ccef-432a-b803-1abd51dd618d', N'CanManageSite')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b32828a6-d631-44ab-8299-2bea39e2f02f', N'63f40459-ccef-432a-b803-1abd51dd618d')

            ");

        }

        public override void Down()
        {
        }
    }
}
