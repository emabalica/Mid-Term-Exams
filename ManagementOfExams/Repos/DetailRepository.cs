/*
using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Repos
{
    public class DetailRepository : IRepository<Detail>
    {
        private readonly ManagementContext _context;

        public DetailRepository(ManagementContext context)
        {
            _context = context;
        }

        public void Create(Detail detail)
        {
            _context.Add(detail);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Detail = _context.Set<Detail>().FirstOrDefault(e => e.Id == id);
            _context.Remove(Detail);
            _context.SaveChanges();
        }

        public List<Detail> GetAll()
        {
            return _context.Set<Detail>().ToList();
        }

        public Detail GetById(Guid id)
        {
            return _context.Set<Detail>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(Detail detail)
        {
            _context.Update(detail);
            _context.SaveChanges();
        }
    }
}
*/