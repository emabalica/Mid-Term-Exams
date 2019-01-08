using System;
using ManagementOfExams.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagementOfExams.Test
{
    [TestClass]
    public class DataSubjectTests
    {
        [TestMethod]
        public void TestSubject_With_Consturctor()
        {
            //Arrange
            string title = "TestT";
            int noOfCredits = 0;

            //Act
            Subject subject = new Subject(title, noOfCredits);

            //Assert
            Assert.AreEqual(title, subject.Title);
            Assert.AreEqual(noOfCredits, subject.NoOfCredits);
        }
        [TestMethod]
        public void TestSubject_WithOut_Consturctor()
        {
            //Arrange
            string title = "TestT";
            int noOfCredits = 7;

            //Act
            Subject subject = new Subject();
            subject.Title = title;
            subject.NoOfCredits = noOfCredits;
            //Exam e = new Exam();
            //subject.Exam = e;

            //Assert
            Assert.AreEqual(title, subject.Title);
            Assert.AreEqual(noOfCredits, subject.NoOfCredits);
            Assert.AreEqual(subject.Exam,null);
            Assert.AreEqual(subject.Teachers, null);

            // Assert.AreEqual(e, subject.Exam);
        }

    }
}
