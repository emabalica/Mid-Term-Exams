using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementOfExams.Models
{
    public class DetailModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string FeedbackMessage { get; set; }

        public int NoOfPages { get; set; }

        public int Rating { get; set; }
    }
}
