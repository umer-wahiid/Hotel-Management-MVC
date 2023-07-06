namespace HManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "image_path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "image_path");
        }
    }
}
