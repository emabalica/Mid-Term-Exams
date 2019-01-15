using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vanguard;

namespace ManagementOfExams.Data
{
    public class Teacher : BaseEntity
    {
        public Teacher()
        {
            
        }

        public Teacher( string firstName, string lastName, string userName, string password, string emailAddress)
        {
            Id = Guid.NewGuid();
            Guard.ArgumentNotNullOrEmpty(firstName, nameof(firstName));
            Guard.ArgumentNotNullOrEmpty(lastName, nameof(lastName));
            Guard.ArgumentNotNullOrEmpty(userName, nameof(userName));
            Guard.ArgumentNotNullOrEmpty(password, nameof(password));
            Guard.ArgumentNotNullOrEmpty(emailAddress, nameof(emailAddress));
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            EmailAddress = emailAddress;

            Exams = new List<Exam>();
        }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get;  set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get;  set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string UserName { get;   set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Password { get;   set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string EmailAddress { get;  set; }

        //[ForeignKey("Subject")]
        //public Guid SubjectId { get; private set; }

        public Subject Subject { get;  set; }

        public IEnumerable<Exam> Exams { get; set; }


        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}