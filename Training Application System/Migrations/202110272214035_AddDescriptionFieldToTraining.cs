namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionFieldToTraining : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "Details");
        }
    }
}
