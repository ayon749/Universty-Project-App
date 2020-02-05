namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignedCourseV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignedCourses", "Credit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignedCourses", "Credit");
        }
    }
}
