namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailAddressToAttendeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "EmailAddress");
        }
    }
}
