namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToTrainingModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainings", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainings", "Name", c => c.String());
        }
    }
}
