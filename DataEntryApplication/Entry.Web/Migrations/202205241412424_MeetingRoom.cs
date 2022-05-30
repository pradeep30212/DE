namespace Entry.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetingRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeetingRooms",
                c => new
                    {
                        MeetingRoomId = c.Int(nullable: false, identity: true),
                        MeetingRoomName = c.String(),
                    })
                .PrimaryKey(t => t.MeetingRoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MeetingRooms");
        }
    }
}
