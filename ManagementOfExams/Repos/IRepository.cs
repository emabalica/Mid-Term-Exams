using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Data;

namespace ManagementOfExams.Repos
{
    interface IRepository
    {
        void Create(Teacher teacher);
        void Delete(Guid id);
        List<Teacher> GetAll();
        Teacher GetById(Guid id);
        void Update(Teacher teacher);
        void Save();
    }
}
