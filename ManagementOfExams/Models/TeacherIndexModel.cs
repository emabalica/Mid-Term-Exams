using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Models
{
    public class TeacherIndexModel
    {
        public IEnumerable<TeacherIndexListingModel> Teachers { set; get; }
    }
}
