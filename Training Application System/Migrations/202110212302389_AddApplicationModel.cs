namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attendee_Id = c.Int(nullable: false),
                        Training_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendees", t => t.Attendee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Trainings", t => t.Training_Id, cascadeDelete: true)
                .Index(t => t.Attendee_Id)
                .Index(t => t.Training_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "Training_Id", "dbo.Trainings");
            DropForeignKey("dbo.Applications", "Attendee_Id", "dbo.Attendees");
            DropIndex("dbo.Applications", new[] { "Training_Id" });
            DropIndex("dbo.Applications", new[] { "Attendee_Id" });
            DropTable("dbo.Applications");
        }
    }
}
