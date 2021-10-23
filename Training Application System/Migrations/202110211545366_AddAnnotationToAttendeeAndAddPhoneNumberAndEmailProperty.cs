namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToAttendeeAndAddPhoneNumberAndEmailProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "PhoneNumber");
        }
    }
}
