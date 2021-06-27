namespace ClgManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        SubmissionTime = c.DateTime(nullable: false),
                        CourseCode = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.CourseCode)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseCode = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        StudentId = c.Int(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseCode)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyMail = c.String(),
                        FacultyMobileNo = c.Long(nullable: false),
                        FacultyAddress = c.String(),
                        FacultyDoj = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentDepartment = c.String(maxLength: 20),
                        CourseName = c.String(),
                        StudentMail = c.String(),
                        StudentMobile = c.Long(nullable: false),
                        StudentAddress = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AssignmentSubmissions",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        SubmissionDate = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.CourseCode);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        AttendanceDate = c.DateTime(nullable: false),
                        IsPresent = c.String(),
                        StudentId = c.Int(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        CalendarId = c.Int(nullable: false, identity: true),
                        DateOfEdit = c.DateTime(nullable: false),
                        Status = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.CalendarId);
            
            CreateTable(
                "dbo.FacultyCourses",
                c => new
                    {
                        FcourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FcourseId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: false)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.FeeDetails",
                c => new
                    {
                        FeeId = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        DateOfPayment = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeeId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.IssueReports",
                c => new
                    {
                        Ticket = c.Long(nullable: false, identity: true),
                        Description = c.String(maxLength: 1500),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Ticket)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LeaveDetails",
                c => new
                    {
                        LeaveDetailsId = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        DateOfLeave = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveDetailsId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        ParentAddress = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        SCourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SCourseId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Parents", "UserId", "dbo.Users");
            DropForeignKey("dbo.LeaveDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.IssueReports", "UserId", "dbo.Users");
            DropForeignKey("dbo.FeeDetails", "StudentId", "dbo.Students");
            DropForeignKey("dbo.FacultyCourses", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Attendances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendances", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.AssignmentSubmissions", "StudentId", "dbo.Students");
            DropForeignKey("dbo.AssignmentSubmissions", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Assignments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Assignments", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Courses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropForeignKey("dbo.Courses", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Faculties", "UserId", "dbo.Users");
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.Parents", new[] { "UserId" });
            DropIndex("dbo.LeaveDetails", new[] { "UserId" });
            DropIndex("dbo.IssueReports", new[] { "UserId" });
            DropIndex("dbo.FeeDetails", new[] { "StudentId" });
            DropIndex("dbo.FacultyCourses", new[] { "FacultyId" });
            DropIndex("dbo.Attendances", new[] { "FacultyId" });
            DropIndex("dbo.Attendances", new[] { "StudentId" });
            DropIndex("dbo.AssignmentSubmissions", new[] { "CourseCode" });
            DropIndex("dbo.AssignmentSubmissions", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Faculties", new[] { "UserId" });
            DropIndex("dbo.Courses", new[] { "FacultyId" });
            DropIndex("dbo.Courses", new[] { "StudentId" });
            DropIndex("dbo.Assignments", new[] { "StudentId" });
            DropIndex("dbo.Assignments", new[] { "CourseCode" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Parents");
            DropTable("dbo.LeaveDetails");
            DropTable("dbo.IssueReports");
            DropTable("dbo.FeeDetails");
            DropTable("dbo.FacultyCourses");
            DropTable("dbo.Calendars");
            DropTable("dbo.Attendances");
            DropTable("dbo.AssignmentSubmissions");
            DropTable("dbo.Students");
            DropTable("dbo.Users");
            DropTable("dbo.Faculties");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
