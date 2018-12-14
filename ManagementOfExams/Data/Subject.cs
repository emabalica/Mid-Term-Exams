using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vanguard;

namespace ManagementOfExams.Data
{
    public class Subject
    {
        public Subject(string title, int noOfCredits)
        {
            Id = Guid.NewGuid();
            Guard.ArgumentNotNullOrEmpty(title, nameof(title));
            Guard.ArgumentNotNull(noOfCredits, nameof(noOfCredits));
            Title = title;
            NoOfCredits = noOfCredits;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; private set; }

        [Required]
        [Range(0,1)]
        public int NoOfCredits { get; private set; }
        
        public ICollection<Teacher> Teachers { get; private set; }

        [ForeignKey("Exam")]
        public Guid ExamId { get; private set; }

        public Exam Exam{ get; private set; }
    }
}
