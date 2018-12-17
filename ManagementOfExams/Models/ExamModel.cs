using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementOfExams.Models
{
    public class ExamModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Observations { get; set; }
        
        public DateTime DateStart { get; set; }
        
        public DateTime DateEnd { get; set; }
    }
}
