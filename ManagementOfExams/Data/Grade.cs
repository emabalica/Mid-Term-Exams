using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vanguard;

namespace ManagementOfExams.Data
{
    public class Grade
    {
        public Grade(int value, DateTime date)
        {
            Id = Guid.NewGuid();
            Guard.ValueNotNull(value, nameof(value));
            Guard.ValueNotNull(date, nameof(date));
            Value = value;
            Date = date;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public int Value { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        [ForeignKey("Exam")]
        public Guid ExamId { get; private set; }

        public Exam Exam { get; private set; }

        //foreignkey
        public Student Student { get; private set; }


    }
}
