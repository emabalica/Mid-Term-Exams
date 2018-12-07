using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace DataLayer
{
    public class Grade
    {
        public Grade(int value, DateTime date, Guid userId)
        {
            Value = value;
            Date = date;
            UserId = userId;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public void AttachUserId(Guid id)
        {
            UserId = id;
        }




    }
}