namespace WebshopBouidi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAppointModelTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppointmentModel", newName: "Appointment");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Appointment", newName: "AppointmentModel");
        }
    }
}
