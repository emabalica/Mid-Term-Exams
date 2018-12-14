/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Data;

namespace ManagementOfExams.Repos
{
    public class ExamRepository : IRepository<Exam>
    {
        private readonly ManagementContext _context;

        public ExamRepository(ManagementContext context)
        {
            _context = context;
        }

        public void Create(Exam exam)
        {
            _context.Add(exam);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Exam = _context.Set<Exam>().FirstOrDefault(e => e.Id == id);
            _context.Remove(Exam);
            _context.SaveChanges();
        }

        public List<Exam> GetAll()
        {
            return _context.Set<Exam>().ToList();
        }

        public Exam GetById(Guid id)
        {
            return _context.Set<Exam>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(Exam exam)
        {
            _context.Update(exam);
            _context.SaveChanges();
        }
    }
}
*/