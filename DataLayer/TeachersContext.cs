using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class TeachersContext : DbContext
    {
        public TeachersContext(DbContextOptions<TeachersContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
