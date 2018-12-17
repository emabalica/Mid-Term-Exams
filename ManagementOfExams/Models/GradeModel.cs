using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementOfExams.Models
{
    public class GradeModel
    {
        [Key]
        public Guid Id { get; set; }

        public int Value { get; set; }

        public DateTime Date { get; set; }
    }
}
