using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GradesContext: DbContext
    {
        public GradesContext(DbContextOptions<GradesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Grade> Grades { get; set; }
    }
}