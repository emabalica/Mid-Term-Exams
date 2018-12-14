using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vanguard;

namespace ManagementOfExams.Data
{
    public class Student
    {
        public Student(string firstName, string lastName, string userName, string password, string emailAddress)
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
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string UserName { get; private set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Password { get; private set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string EmailAddress { get; private set; }

        public ICollection<Exam> Exams { get; private set; }

        //[InverseProperty("StudentId")]
        public ICollection<Grade> Grades { get; private set; }

        //[InverseProperty("StudentId")]
        public ICollection<Detail> Details { get; private set; }

    }
}
