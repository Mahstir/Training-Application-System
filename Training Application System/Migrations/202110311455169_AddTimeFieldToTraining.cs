namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeFieldToTraining : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "Time");
        }
    }
}
