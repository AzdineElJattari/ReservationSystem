namespace WebshopBouidi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInCreationDateOfContactModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "CreationDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "CreationDate", c => c.String(nullable: false));
        }
    }
}
