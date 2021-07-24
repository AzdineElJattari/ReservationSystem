namespace WebshopBouidi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BugFixMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointment", "AppointmentTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointment", "AppointmentTime", c => c.String(nullable: false));
        }
    }
}
