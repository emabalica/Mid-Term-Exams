/*
using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Repos
{
    public class GradeRepository : IRepository<Grade>
    {
        private readonly ManagementContext _context;

        public GradeRepository(ManagementContext context)
        {
            _context = context;
        }

        public void Create(Grade grade)
        {
            _context.Add(grade);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Grade = _context.Set<Grade>().FirstOrDefault(e => e.Id == id);
            _context.Remove(Grade);
            _context.SaveChanges();
        }

        public List<Grade> GetAll()
        {
            return _context.Set<Grade>().ToList();
        }

        public Grade GetById(Guid id)
        {
            return _context.Set<Grade>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(Grade grade)
        {
            _context.Update(grade);
            _context.SaveChanges();
        }
    }
}
*/