    using System;
    using ManagementOfExams.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ManagementOfExams.Test
    {
        [TestClass]
        public class DataExamTests
        {
            [TestMethod]
            public void TestExam_With_Consturctor()
            {
                //Arrange
                string title = "TestT";
                string observations = "ObservationsO";
                DateTime dateStart = new DateTime(2017, 8, 5);
                DateTime dateEnd = new DateTime(2018, 8, 5);

                //Act
                Exam exam = new Exam(title, observations,dateStart,dateEnd);

                //Assert
                Assert.AreEqual(title, exam.Title);
                Assert.AreEqual(observations, exam.Observations);
                Assert.AreEqual(dateStart, exam.DateStart);
                Assert.AreEqual(dateEnd, exam.DateEnd);
            }

            [TestMethod]
            public void TestExam_WithOut_Consturctor()
            {
                //Arrange
                string title = "TestT";
                string observations = "ObservationsO";
                DateTime dateStart = new DateTime(2017, 8, 5);
                DateTime dateEnd = new DateTime(2018, 8, 5);

                //Act

                Exam exam = new Exam();

                exam.Title =title;
                exam.Observations = observations;
                exam.DateStart = dateStart;
                exam.DateEnd = dateEnd;

                //Assert
                Assert.AreEqual(exam.Student, null);
                Assert.AreEqual(exam.Subjects, null);
                Assert.AreEqual(exam.Grade, null);
                Assert.AreEqual(exam.Detail, null);


            }

        }
    }
