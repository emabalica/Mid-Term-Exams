/*
using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Repos
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly ManagementContext _context;

        public StudentRepository(ManagementContext context)
        {
            _context = context;
        }
        public void Create(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Student = _context.Set<Student>().FirstOrDefault(e => e.Id == id);
            _context.Remove(Student);
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Set<Student>().ToList();
        }

        public Student GetById(Guid id)
        {
            return _context.Set<Student>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
        }
    }
}
*/