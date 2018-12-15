using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ManagementOfExams.Repos
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly ManagementContext _context;

        public TeacherRepository(ManagementContext context)
        {
            _context = context;
        }
        public void Create(Teacher teacher)
        {
            _context.Add(teacher);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Teacher = _context.Set<Teacher>().FirstOrDefault(e => e.Id == id);
            _context.Remove(Teacher);
            _context.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            return _context.Set<Teacher>().ToList(); ;
        }

        public Teacher GetById(Guid id)
        {
            return _context.Set<Teacher>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(Teacher teacher)
        {
            _context.Update(teacher);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
