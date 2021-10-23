namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListofTrainingToDomainModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "Application_Id", c => c.Int());
            CreateIndex("dbo.Trainings", "Application_Id");
            AddForeignKey("dbo.Trainings", "Application_Id", "dbo.Applications", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainings", "Application_Id", "dbo.Applications");
            DropIndex("dbo.Trainings", new[] { "Application_Id" });
            DropColumn("dbo.Trainings", "Application_Id");
        }
    }
}
