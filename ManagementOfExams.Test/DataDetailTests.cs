using System;
using ManagementOfExams.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagementOfExams.Test
{
    [TestClass]
    public class DataDetailTests
    {
        [TestMethod]
        public void TestDetail_With_Consturctor()
        {
            //Arrange
            DateTime checkIn = new DateTime(2018, 4, 5);
            DateTime checkOut = new DateTime(2018, 7, 5);
            string feedbackMessage = "feedbackMessageFM";
            int noOfPages = 5;
            int rating = 5;
            
            //Act
            Detail detail = new Detail(checkIn, checkOut, feedbackMessage, noOfPages, rating);

            //Assert

            Assert.AreEqual(checkIn, detail.CheckIn);
            Assert.AreEqual(checkOut, detail.CheckOut);
            Assert.AreEqual(feedbackMessage, detail.FeedbackMessage);
            Assert.AreEqual(noOfPages, detail.NoOfPages);
            Assert.AreEqual(rating, detail.Rating);
        }

        [TestMethod]
        public void TestDetail_WithOut_Consturctor()
        {
            //Arrange
            DateTime checkIn = new DateTime(2018, 4, 5);
            DateTime checkOut = new DateTime(2018, 7, 5);
            string feedbackMessage = "feedbackMessageFM";
            int noOfPages = 5;
            int rating = 5;
            //Act

            Detail detail = new Detail();

            detail.FeedbackMessage = feedbackMessage;
            detail.NoOfPages = noOfPages;
            detail.Rating = rating;
            detail.CheckIn = checkIn;
            detail.CheckOut = checkOut;

            //Assert
            Assert.AreEqual(detail.Student, null);
            Assert.AreEqual(detail.Exam, null);


        }

    }
}
