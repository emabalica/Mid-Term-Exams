using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vanguard;

namespace ManagementOfExams.Data
{
    public class Exam : BaseEntity
    {
        public Exam()
        {
            
        }

        public Exam(string title, string observations, DateTime dateStart, DateTime dateEnd)
        {
            Id = Guid.NewGuid();
            Guard.ArgumentNotNullOrEmpty(title, nameof(title));
            Guard.ArgumentNotNull(observations, nameof(observations));
            Guard.ArgumentNotNull(dateStart,nameof(dateStart));
            Guard.ArgumentNotNull(dateEnd, nameof(dateEnd));
            Title = title;
            Observations = observations;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Observations { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }


        public ICollection<Subject> Subjects { get; private set; }

        public ICollection<Grade> Grade { get; private set; }

        public ICollection<Detail> Detail { get; private set; }

        //[ForeignKey("Student")]
        //public Guid StudentId { get; private set; }

        public Student Student { get; set; }

    }
}