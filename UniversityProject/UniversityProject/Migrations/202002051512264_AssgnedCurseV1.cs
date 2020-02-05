namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssgnedCurseV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedCourses",
                c => new
                    {
                        AssignedCourseId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignedCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.AssignedCourses", new[] { "CourseId" });
            DropTable("dbo.AssignedCourses");
        }
    }
}
