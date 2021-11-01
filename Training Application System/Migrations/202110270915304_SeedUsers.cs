namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8e6c24b0-df26-4ad9-b6e4-fe101a9c5c3f', N'guest@microsoft.com', 0, N'AMHcXYftzAYlNPMzVAlDKo2ZwCxhF/9pFyO3j2JBD9zd9wxT5vRxl4ngoBV//Jp+1w==', N'87ba95f5-0499-4d24-a812-59194cab41ed', NULL, 0, 0, NULL, 1, 0, N'guest@microsoft.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc153076-179c-4a93-bf8b-1e6981e4774e', N'admin@coventry.com', 0, N'AFKw6O1RWAmFT/cxkUhderFS7J7PI/cT99cFMJQA+ikdYTBkLJPn66Gakg7myovHTQ==', N'668abf7d-9cef-40ee-9a4a-f91458993092', NULL, 0, 0, NULL, 1, 0, N'admin@coventry.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4c6138c1-f97b-4940-8c8c-323e3ec90992', N'CanCreateTrainings')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bc153076-179c-4a93-bf8b-1e6981e4774e', N'4c6138c1-f97b-4940-8c8c-323e3ec90992')

");
        }
        
        public override void Down()
        {
        }
    }
}
