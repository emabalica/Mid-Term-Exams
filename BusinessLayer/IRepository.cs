using System;
using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(Guid id);
        List<T> GetAll();
        T GetById(Guid id);
        void Update(T entity);
    }
}