using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class UserRepository : IRepository<User>
    {
        private readonly UsersContext _context;

        public UserRepository(UsersContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _context.Set<User>().FirstOrDefault(e => e.Id == id);
            _context.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Set<User>().ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Set<User>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

       
    }
}
