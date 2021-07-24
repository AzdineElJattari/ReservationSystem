namespace WebshopBouidi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppointmentTimeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "AppointmentTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointment", "AppointmentTime");
        }
    }
}
