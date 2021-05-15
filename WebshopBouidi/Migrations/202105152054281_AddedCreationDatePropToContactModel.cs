namespace WebshopBouidi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreationDatePropToContactModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "CreationDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "CreationDate");
        }
    }
}
