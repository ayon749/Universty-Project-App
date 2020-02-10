namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassRoomV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ClassRoomId = c.Int(nullable: false, identity: true),
                        RoomNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassRoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassRooms");
        }
    }
}
