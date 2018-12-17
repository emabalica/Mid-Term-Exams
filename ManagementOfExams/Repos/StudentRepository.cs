using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Repos
{
    public class StudentRepository : Repository
    {
        public StudentRepository(ManagementContext studentContext) : base(studentContext)
        {
        }
    }
}