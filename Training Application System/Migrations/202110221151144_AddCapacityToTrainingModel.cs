namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCapacityToTrainingModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "Capacity");
        }
    }
}
