using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class SubjectsContext : DbContext
    {
        public SubjectsContext(DbContextOptions<SubjectsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Subject> Subjects { get; set; }
    }
}