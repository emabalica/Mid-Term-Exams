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
    public class TeacherControllerTests
    {
        [TestMethod]
        public void Teachers_Controller_Test_On_Index()
        {
            //Arrange
            var repo = Substitute.For<IRepository>();
            ICollection<Teacher> expectedTeachers = new[] { new Teacher() };
            repo.GetAll<Teacher>().Returns(expectedTeachers);
            var sut = new TeachersController(repo);

            //Act
            var actual = sut.Index().Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectedTeachers, viewResult.Model);
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Edit_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            Teacher expectedTeacher = new Teacher(firstName, lastName, userName, password, emailAdress);
            expectedTeacher.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id).Returns(expectedTeacher);
            //Act
            var actual = sut.Edit(id).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectedTeacher, viewResult.Model);
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Edit_With_NonExistent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id);

            //Act
            var actual = sut.Edit(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual,typeof(NotFoundResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Details_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            Teacher expectedTeacher = new Teacher(firstName, lastName, userName, password, emailAdress);
            expectedTeacher.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id).Returns(expectedTeacher);
            //Act
            var actual = sut.Details(id).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectedTeacher, viewResult.Model);
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Details_With_NonExistent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id);

            //Act
            var actual = sut.Details(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Delete_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            Teacher expectedTeacher = new Teacher(firstName, lastName, userName, password, emailAdress);
            expectedTeacher.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id).Returns(expectedTeacher);
            //Act
            var actual = sut.Delete(id).Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
            var viewResult = actual;
            Assert.AreEqual(expectedTeacher, viewResult.Model);
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Delete_With_NonExistent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id);

            //Act
            var actual = sut.Delete(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Delete_With_Null_Id()
        {
            //Arrange
            var id = Guid.Empty;
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id);

            //Act
            var actual = sut.Delete(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Delete_Confirmed_With_Existent_Id()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            Teacher expectedTeacher = new Teacher(firstName, lastName, userName, password, emailAdress);
            expectedTeacher.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.GetById<Teacher>(id).Returns(expectedTeacher);
            //Act
            var actual = sut.DeleteConfirmed(id).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_CreateModel_With_Valid_Model()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            Teacher expectedTeacher = new Teacher(firstName, lastName, userName, password, emailAdress);
            expectedTeacher.Id = id;

            TeacherModel expectedModel = new TeacherModel();

            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.Create(expectedTeacher);

            //Act
            var actual = sut.Create(expectedModel).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_CreateModel_With_Invalid_Model()
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

            TeacherModel expectedModel = new TeacherModel();
            expectedModel.EmailAddress = " ";
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.Create(expectedTeacher);

            //Act
            sut.ModelState.AddModelError("FirstName","Firstname Required");
            var actual = sut.Create(expectedModel).Result;
            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_Create()
        {
            //Arrange
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);

            //Act
            var actual = sut.Create();

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_EditModel_With_Valid_Model()
        {
            //Arrange
            Guid id = new Guid("f616cc8c-2223-4145-b7d0-232a1f6f0795");
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            Teacher expectedTeacher = new Teacher(firstName, lastName, userName, password, emailAdress);
            expectedTeacher.Id = id;

            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.Update(expectedTeacher);

            //Act
            var actual = sut.Edit(id,expectedTeacher).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_EditModel_With_Invalid_Model()
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

            TeacherModel expectedModel = new TeacherModel();
            expectedModel.EmailAddress = " ";
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.Update(expectedTeacher);

            //Act
            sut.ModelState.AddModelError("FirstName", "Firstname Required");
            var actual = sut.Edit(id,expectedTeacher).Result;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod]
        public void Teachers_Controller_Test_On_EditModel_With_Invalid_Id()
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

            Guid faultId = new Guid("1e4966f0-68f7-4f24-9f4f-53d528787be5");

            TeacherModel expectedModel = new TeacherModel();
            expectedModel.EmailAddress = " ";
            var repo = Substitute.For<IRepository>();
            var sut = new TeachersController(repo);
            repo.Update(expectedTeacher);

            //Act
            var actual = sut.Edit(faultId, expectedTeacher).Result;

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