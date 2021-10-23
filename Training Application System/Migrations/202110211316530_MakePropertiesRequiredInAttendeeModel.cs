namespace Training_Application_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePropertiesRequiredInAttendeeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Attendees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Attendees", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendees", "EmailAddress", c => c.String());
            AlterColumn("dbo.Attendees", "LastName", c => c.String());
            AlterColumn("dbo.Attendees", "FirstName", c => c.String());
        }
    }
}
