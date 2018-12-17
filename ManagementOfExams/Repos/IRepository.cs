using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Data;

namespace ManagementOfExams.Repos
{
    public interface IRepository
    {
        void Create<T>(T entity)
            where T : BaseEntity;

        void Update<T>(T entity)
            where T : BaseEntity;

        void Delete<T>(T entity)
            where T : BaseEntity;

        Task<ICollection<T>> GetAll<T>()
            where T : BaseEntity;

        Task<T> GetById<T>(Guid Id)
            where T : BaseEntity;

        void Save();
    }
}
