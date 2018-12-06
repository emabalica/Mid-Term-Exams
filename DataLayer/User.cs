using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class User
    {
        public Guid Id { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; private set; }

        [Required]
        [StringLength(10)]
        public string RegistrationNumber { get; private set; }

        public string UserName { get; private set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Password { get; private set; }

    }
}
