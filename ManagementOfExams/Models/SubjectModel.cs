using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementOfExams.Models
{
    public class SubjectModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public int NoOfCredits { get;  set; }
    }
}
