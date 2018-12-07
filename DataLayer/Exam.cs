using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Exam
    {
        public Exam(DateTime date, List<User> users, Guid subjectId)
        {
            Date = date;
            Users = users;
            SubjectId = subjectId;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public List<User> Users { get; set; }

        public Guid SubjectId { get; set; }

        public void AttachSubjectId(Guid id)
        {
            SubjectId = id;
        }
    }
}