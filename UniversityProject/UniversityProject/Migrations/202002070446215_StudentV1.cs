namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        RegistrationNo = c.String(),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
