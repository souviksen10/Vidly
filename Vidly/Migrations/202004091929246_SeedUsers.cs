namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'1256ecf0-7717-4334-b821-d39bba9583c6', N'guest@vidly.com', 0, N'AB1p5bMtTl7UJHhKEe5lPtwJhV1X33PTAmrP6NmriaKKCiysFazo/Lv8sv+W0aqfFQ==', N'44aa1299-b1cb-45fb-9786-acd5dc0fd71d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f05855b1-c479-4a5e-be86-9f156a125c8f', N'admin@vidly.com', 0, N'AKA03/j5FvP/NdhUP4pULCYGkpRuQOkTYpMXXWItM953Bn/FCr57VPK6ucMyeg190g==', N'30cb3605-7fd8-429f-89ab-755f23b039ee', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'def52916-0b5b-4653-9d30-273da68e0497', N'CanManageMovies')     

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f05855b1-c479-4a5e-be86-9f156a125c8f', N'def52916-0b5b-4653-9d30-273da68e0497')                
                ");
        }

        public override void Down()
        {
        }
    }
}
