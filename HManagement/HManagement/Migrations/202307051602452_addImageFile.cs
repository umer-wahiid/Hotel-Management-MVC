namespace HManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "Image");
        }
    }
}
