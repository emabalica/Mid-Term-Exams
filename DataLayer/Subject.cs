using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class Subject
    {
        public Subject(List<Teacher> teachers, List<Exam> exams)
        {
            Teachers = teachers;
            Exams = exams;
        }

        [Key]
        public Guid Id { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
