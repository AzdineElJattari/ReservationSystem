namespace WebshopBouidi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentmodelproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointmentModel", "AppointmentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppointmentModel", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppointmentModel", "Message");
            DropColumn("dbo.AppointmentModel", "AppointmentDate");
        }
    }
}
