using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vanguard;

namespace ManagementOfExams.Data
{
    public class Detail
    {
        public Detail(DateTime checkIn, DateTime checkOut, string feedbackMessage, int noOfPages, int rating)
        {
            Id = new Guid();
            Guard.ArgumentNotNull(checkIn, nameof(checkIn));
            Guard.ArgumentNotNull(checkIn, nameof(CheckOut));
            Guard.ArgumentNotNullOrEmpty(feedbackMessage, nameof(feedbackMessage));
            Guard.ValueNotNull(noOfPages, nameof(noOfPages));
            Guard.ValueNotNull(rating, nameof(rating));
            CheckIn = checkIn;
            CheckOut = checkOut;
            FeedbackMessage = feedbackMessage;
            NoOfPages = noOfPages;
            Rating = rating;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public DateTime CheckIn { get; private set; }

        [Required]
        public DateTime CheckOut { get; private set; }

        [Required]
        [MaxLength(200)]
        public string FeedbackMessage { get; private set; }

        [Required]
        [Range(0, 2)]
        public int NoOfPages { get; private set; }

        [Required]
        [Range(0, 1)]
        public int Rating { get; private set; }

        //foreign keys
        public Student Student { get; private set; }

        [ForeignKey("Exam")]
        public Guid ExamId { get; private set; }

        public Exam Exam { get; private set; }
    }
}
