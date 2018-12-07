using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly TeachersContext _context;

        public TeacherRepository(TeachersContext context)
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
            return _context.Set<Teacher>().ToList();
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
    }
}