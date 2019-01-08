using System;
using System.ComponentModel.DataAnnotations;
using Vanguard;

namespace ManagementOfExams.Data
{
    public class Detail : BaseEntity
    {
        public Detail()
        {
            //
        }

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


        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        [MaxLength(200)]
        public string FeedbackMessage { get; set; }

        [Required]
        [Range(0, 50)]
        public int NoOfPages { get; set; }

        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }

        //foreign keys
        public Student Student { get; set; }

        //[ForeignKey("Exam")]
        //public Guid ExamId { get; private set; }

        public Exam Exam { get; private set; }
    }
}
