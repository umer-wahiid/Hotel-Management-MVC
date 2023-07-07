namespace HManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Image");
        }
    }
}
