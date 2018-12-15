using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Data;

namespace ManagementOfExams.Repos
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(Guid id);
        List<T> GetAll();


        T GetById(Guid id);
        void Update(T entity);
        void Save();
    }
}
