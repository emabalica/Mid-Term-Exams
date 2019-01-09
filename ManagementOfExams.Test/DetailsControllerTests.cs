using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Controllers;
using ManagementOfExams.Data;
using ManagementOfExams.Models;
using ManagementOfExams.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace ManagementOfExams.Test
{
    [TestClass]
    public class DetailsControllerTests
    {
        [TestMethod]
        public void Details_Controller_Test_On_Index()
        {
            //Arrange
            var repo = Substitute.For<IRepository>();
            ICollection<Detail> expectedDetails = new[] { new Detail(),  };
            repo.GetAll<Detail>().Returns(expectedDetails);
            var sut = new DetailsController(repo);

            //Act
            var actual = sut.Index().Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectedDetails, viewResult.Model);
        }

        [TestMethod]
        public void Details_Controller_Test_On_Edit_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn,checkOut,feedBackMessage,noOfPages,rating);
            expectaDetail.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id).Returns(expectaDetail);
            //Act
            var actual = sut.Edit(id).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectaDetail, viewResult.Model);
        }

        [TestMethod]
        public void Details_Controller_Test_On_Edit_With_NonExistent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id);

            //Act
            var actual = sut.Edit(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_Details_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id).Returns(expectaDetail);
            //Act
            var actual = sut.Details(id).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectaDetail, viewResult.Model);
        }

        [TestMethod]
        public void Details_Controller_Test_On_Details_With_NonExistent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id);

            //Act
            var actual = sut.Details(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_Delete_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id).Returns(expectaDetail);
            //Act
            var actual = sut.Delete(id).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectaDetail, viewResult.Model);
        }

        [TestMethod]
        public void Details_Controller_Test_On_Delete_With_NonExistent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id);

            //Act
            var actual = sut.Delete(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_Delete_With_Null_Id()
        {
            //Arrange
            var id = Guid.Empty;
            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id);

            //Act
            var actual = sut.Delete(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_Delete_Confirmed_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.GetById<Detail>(id).Returns(expectaDetail);
            //Act
            var actual = sut.DeleteConfirmed(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_CreateModel_With_Valid_Model()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;

            DetailModel expectedModel = new DetailModel();

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.Create(expectaDetail);

            //Act
            var actual = sut.Create(expectedModel).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_CreateModel_With_Invalid_Model()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;

            DetailModel expectedModel = new DetailModel();

            expectedModel.FeedbackMessage = " ";
            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.Create(expectaDetail);

            //Act
            sut.ModelState.AddModelError("Title", "Title Required");
            var actual = sut.Create(expectedModel).Result;
            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_Create()
        {
            //Arrange
            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);

            //Act
            var actual = sut.Create();

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_EditModel_With_Valid_Model()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;
            

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.Update(expectaDetail);

            //Act
            var actual = sut.Edit(id, expectaDetail).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_EditModel_With_Invalid_Model()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;

            DetailModel expectedModel = new DetailModel();

            expectedModel.FeedbackMessage = " ";

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.Update(expectaDetail);

            //Act
            sut.ModelState.AddModelError("FirstName", "Firstname Required");
            var actual = sut.Edit(id, expectaDetail).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_Controller_Test_On_EditModel_With_Invalid_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string feedBackMessage = "TestT";
            int noOfPages = 10;
            int rating = 10;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now.AddDays(1);

            Detail expectaDetail = new Detail(checkIn, checkOut, feedBackMessage, noOfPages, rating);
            expectaDetail.Id = id;

            Guid faultId = new Guid("1e4966f0-68f7-4f24-9f4f-53d528787be5");

            var repo = Substitute.For<IRepository>();
            var sut = new DetailsController(repo);
            repo.Update(expectaDetail);

            //Act
            var actual = sut.Edit(faultId, expectaDetail).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }
        /*
        [TestMethod]
        public void Teachers_Controller_Test_On_EditModel_With_Database_Exception()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string firstName = "a";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            Teacher expectedTeacher = new Teacher(firstName, lastName, userName, password, emailAdress);
            expectedTeacher.Id = id;

            Teacher unexpectedTeacher = new Teacher();
            

            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.Update(unexpectedTeacher);

            //Act
            var actual = sut.Edit(id, expectedTeacher).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }*/
    }
}