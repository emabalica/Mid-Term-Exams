using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ExamsContext: DbContext
    {
        public ExamsContext(DbContextOptions<ExamsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Exam> Exams { get; set; }
    }
}