using System;
using System.Collections.Generic;
using System.Text;
using ManagementOfExams.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagementOfExams.Test
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void DetailModelTest()
        {
            Guid testId = new Guid();
            DateTime testStartDate = new DateTime(2000, 1, 1, 12, 0, 0);
            DateTime testEndDate = new DateTime(2000, 1, 1, 12, 50, 0);
            var model = new DetailModel()
            {
                Id = testId,
                CheckIn = testStartDate,
                CheckOut = testEndDate,
                FeedbackMessage = "feedback",
                NoOfPages = 5,
                Rating = 5
            };

            var result = TestModelHelper.Validate(model);

            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(testId, model.Id);
            Assert.AreEqual(testStartDate, model.CheckIn);
            Assert.AreEqual(testEndDate, model.CheckOut);
            Assert.AreEqual("feedback", model.FeedbackMessage);
            Assert.AreEqual(5, model.NoOfPages);
            Assert.AreEqual(5, model.Rating);
        }

        [TestMethod]
        public void ErrorViewModelTest()
        {
            var model = new ErrorViewModel()
            {
                RequestId = "reqId"
            };

            var result = TestModelHelper.Validate(model);

            Assert.AreEqual(0, result.Count);
            Assert.AreEqual("reqId", model.RequestId);
        }

        [TestMethod]
        public void ExamModelTest()
        {
            Guid testId = new Guid();
            DateTime testStartDate = new DateTime(2000, 1, 1, 12, 0, 0);
            DateTime testEndDate = new DateTime(2000, 1, 1, 12, 50, 0);
            var model = new ExamModel()
            {
                Id = testId,
                DateStart = testStartDate,
                DateEnd = testEndDate,
                Observations = "obs",
                Title = "Title"
            };

            var result = TestModelHelper.Validate(model);

            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(testId, model.Id);
            Assert.AreEqual(testStartDate, model.DateStart);
            Assert.AreEqual(testEndDate, model.DateEnd);
            Assert.AreEqual("obs", model.Observations);
            Assert.AreEqual("Title", model.Title);
        }

        [TestMethod]
        public void GradeModelTest()
        {
            Guid testId = new Guid();
            DateTime testDate = new DateTime(2000, 1, 1);
            var model = new GradeModel()
            {
                Date = testDate,
                Id = testId,
                Value = 10
            };

            var result = TestModelHelper.Validate(model);

            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(testId, model.Id);
            Assert.AreEqual(testDate, model.Date);
            Assert.AreEqual(10, model.Value);
        }

        [TestMethod]
        public void StudentModelTest()
        {
            Guid testId = new Guid();
            var model = new StudentModel()
            {
                EmailAddress = "mail@mail.com",
                FirstName = "FirstName",
                Id = testId,
                LastName = "LastName",
                Password = "pass",
                UserName = "UserName"
            };

            var result = TestModelHelper.Validate(model);

            Assert.AreEqual(0, result.Count);
            Assert.AreEqual("pass", model.Password);
            Assert.AreEqual("FirstName", model.FirstName);
            Assert.AreEqual("LastName", model.LastName);
            Assert.AreEqual("UserName", model.UserName);
            Assert.AreEqual("mail@mail.com", model.EmailAddress);
            Assert.AreEqual(testId, model.Id);
        }

        [TestMethod]
        public void SubjectModelTest()
        {
            Guid testId = new Guid();
            var model = new SubjectModel()
            {
                Id = testId,
                NoOfCredits = 5,
                Title = "Subject"
            };

            var result = TestModelHelper.Validate(model);

            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(testId, model.Id);
            Assert.AreEqual(5, model.NoOfCredits);
            Assert.AreEqual("Subject", model.Title);
        }

        [TestMethod]
        public void TeacherModelTest()
        {
            Guid testId = new Guid();
            var model = new TeacherModel()
            {
                EmailAddress = "mail@mail.com",
                FirstName = "John",
                LastName = "Doe",
                UserName = "username",
                Password = "pass",
                Id = testId
            };

            var result = TestModelHelper.Validate(model);

            Assert.AreEqual(0, result.Count);
            Assert.AreEqual("John", model.FirstName);
            Assert.AreEqual("Doe", model.LastName);
            Assert.AreEqual("username", model.UserName);
            Assert.AreEqual("mail@mail.com", model.EmailAddress);
            Assert.AreEqual("pass", model.Password);
            Assert.AreEqual(testId, model.Id);
        }
    }
}
