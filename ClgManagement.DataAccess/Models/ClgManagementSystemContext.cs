namespace ClgManagement.DataAccess
{
    using ClgManagement.DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ClgManagementSystemContext : DbContext
    {
  
        public ClgManagementSystemContext()
            : base("name=ClgManagementSystemContext1")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Parent> Parent { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<FacultyCourse> FacultyCourses { get; set; }

        public DbSet<FeeDetails> FeeDetails { get; set; }

        public DbSet<IssueReport> IssueReports { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<LeaveDetails>LeaveDetails { get; set; }

    }

   
}