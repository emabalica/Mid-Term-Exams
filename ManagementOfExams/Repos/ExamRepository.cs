using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Data;

namespace ManagementOfExams.Repos
{
    public class ExamRepository : Repository
    {
        public ExamRepository(ManagementContext examContext) : base(examContext)
        {
        }
    }
}