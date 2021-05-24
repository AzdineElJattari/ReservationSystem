namespace WebshopBouidi.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeAppointmentDatePropToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointment", "AppointmentDate", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Appointment", "AppointmentDate", c => c.DateTime(nullable: false));
        }
    }
}
