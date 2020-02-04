namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherV1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "DesignationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "DesignationId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "DesignationId", cascadeDelete: true);
            DropColumn("dbo.Teachers", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Designation", c => c.String());
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropColumn("dbo.Teachers", "DesignationId");
        }
    }
}
