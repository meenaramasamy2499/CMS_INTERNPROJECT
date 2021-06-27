namespace ClgManagement.DataAccess.Migrations
{
    using ClgManagement.DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClgManagement.DataAccess.ClgManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClgManagement.DataAccess.ClgManagementSystemContext context)
        {

            //var Student1 = new Student { StudentDepartment = "VisCom", CourseName = "Athlete", StudentMail = "viratk@123", StudentAddress = "Mumbai", StudentMobile = 9876453210, UserId = 5 };
            //context.Students.AddOrUpdate(user => user.StudentId, Student1);
            //var Faculty1 = new Faculty { UserId = 3, FacultyMail = "Sam@1234", FacultyAddress = "Hyderabad", FacultyMobileNo = 9786542310, FacultyDoj = DateTime.Parse("1 / 1 / 2012 12:22:00 AM") };
            //context.Faculties.AddOrUpdate(user => user.FacultyId, Faculty1);
            //var Course1 = new Course { CourseCode = 1, CourseName = "VLSI", FacultyId = 1, StudentId = 1 };
            //context.Courses.AddOrUpdate(user => user.CourseCode, Course1);
            //var Assignment1 = new Assignment { Question = "What is an API", CourseCode = 1, StudentId = 1, SubmissionTime = DateTime.Parse("1 / 1 / 2012 12:22:00 AM") };
            //context.Assignments.AddOrUpdate(user => user.AssignmentId, Assignment1);
            //var FeeDetail1 = new FeeDetails { Amount = 100000, DateOfPayment = DateTime.Parse("1 / 1 / 2012 12:22:00 AM"), StudentId = 1 };
            //context.FeeDetails.AddOrUpdate(user => user.FeeId, FeeDetail1);
            //var Student1 = new Student { StudentDepartment = "ECE", CourseName = "Physics", StudentMail = "virat@123", StudentAddress = "Lucknow", StudentMobile = 7065732132, UserId = 6 };
            //var Student2 = new Student { StudentDepartment = "Civil", CourseName = "CADD Lab", StudentMail = "arun@123", StudentAddress = "Chennai", StudentMobile = 7067532132, UserId = 8 };
            //context.Students.AddOrUpdate(user => user.StudentId, Student1, Student2);
            var user1 = new User { FirstName = "Meena",LastName = "R", UserName = "meena@1234", UserType = "parent", Password = "meena@123" };
            context.Users.AddOrUpdate(user => user.UserId, user1);

            


            ////var calendar2 = new Calendar { Date = DateTime.Parse("1 / 1 / 2012 12:22:00 AM"), Status = "Holiday", Reason = "Local Holiday" };
            ////context.Calendars.AddOrUpdate(calendar => calendar.CalendarId, calendar2);
        }
    }
}
