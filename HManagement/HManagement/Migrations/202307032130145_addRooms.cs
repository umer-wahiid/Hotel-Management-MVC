namespace HManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRooms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNo = c.Int(nullable: false),
                        RoomType = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Availability = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rooms");
        }
    }
}
