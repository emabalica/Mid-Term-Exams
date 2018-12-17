using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;

namespace ManagementOfExams.Repos
{
    public class TeacherRepository : Repository
    {
        public TeacherRepository(ManagementContext teacherContext) : base(teacherContext)
        {
        }
    }
}
