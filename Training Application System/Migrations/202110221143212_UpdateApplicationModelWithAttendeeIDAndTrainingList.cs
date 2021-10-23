namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateApplicationModelWithAttendeeIDAndTrainingList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainings", "Application_Id", "dbo.Applications");
            DropIndex("dbo.Trainings", new[] { "Application_Id" });
            RenameColumn(table: "dbo.Applications", name: "Attendee_Id", newName: "AttendeeId");
            RenameIndex(table: "dbo.Applications", name: "IX_Attendee_Id", newName: "IX_AttendeeId");
            DropColumn("dbo.Trainings", "Application_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainings", "Application_Id", c => c.Int());
            RenameIndex(table: "dbo.Applications", name: "IX_AttendeeId", newName: "IX_Attendee_Id");
            RenameColumn(table: "dbo.Applications", name: "AttendeeId", newName: "Attendee_Id");
            CreateIndex("dbo.Trainings", "Application_Id");
            AddForeignKey("dbo.Trainings", "Application_Id", "dbo.Applications", "Id");
        }
    }
}
