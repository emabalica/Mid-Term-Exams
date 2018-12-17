using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Repos
{
    public class SubjectRepository : Repository
    {
        public SubjectRepository(ManagementContext subjectContext) : base(subjectContext)
        {
        }
    }
}
