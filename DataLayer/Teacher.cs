using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Teacher
    {
        public Teacher(string firstName, string lastName, string userName, string password, List<Subject> subjects)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Subjects = subjects;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; private set; }

        public string UserName { get; private set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Password { get; private set; }

        public List<Subject> Subjects { get; set; }

       
    }
}