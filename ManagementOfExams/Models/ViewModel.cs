using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Models
{
    public class ViewModel
    {
        public StudentModel student = new StudentModel();
        public SubjectModel subject { get; set; }
        public GradeModel grades { get; set; }
        public ExamModel exams { get; set; }
        public ExamModel teachers { get; set; }

    }
}
