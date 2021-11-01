namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNavigationPropertyToAttendee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "TrainingId", c => c.Int());
            CreateIndex("dbo.Attendees", "TrainingId");
            AddForeignKey("dbo.Attendees", "TrainingId", "dbo.Trainings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendees", "TrainingId", "dbo.Trainings");
            DropIndex("dbo.Attendees", new[] { "TrainingId" });
            DropColumn("dbo.Attendees", "TrainingId");
        }
    }
}
