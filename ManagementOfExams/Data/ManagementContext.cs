using Microsoft.EntityFrameworkCore;
using ManagementOfExams.Models;

namespace ManagementOfExams.Data
{
    public sealed class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Detail> Details { get; set; }
        //public DbSet<ManagementOfExams.Models.TeacherIndexListingModel> TeacherIndexListingModel { get; set; }
    }

}
