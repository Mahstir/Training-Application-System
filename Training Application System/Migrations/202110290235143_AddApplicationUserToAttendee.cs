namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserToAttendee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "ApplicationUserId", c => c.Int());
            AddColumn("dbo.Attendees", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "TrainingId", c => c.Int());
            CreateIndex("dbo.Attendees", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "TrainingId");
            AddForeignKey("dbo.AspNetUsers", "TrainingId", "dbo.Trainings", "Id");
            AddForeignKey("dbo.Attendees", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendees", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "TrainingId", "dbo.Trainings");
            DropIndex("dbo.AspNetUsers", new[] { "TrainingId" });
            DropIndex("dbo.Attendees", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "TrainingId");
            DropColumn("dbo.Attendees", "ApplicationUser_Id");
            DropColumn("dbo.Attendees", "ApplicationUserId");
        }
    }
}
