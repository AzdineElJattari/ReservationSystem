namespace WebshopBouidi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAppointmentDateTimeToNullableV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppointmentModel", "AppointmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppointmentModel", "AppointmentDate", c => c.DateTime(nullable: false));
        }
    }
}
