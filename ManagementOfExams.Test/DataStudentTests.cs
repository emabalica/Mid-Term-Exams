using System;
using ManagementOfExams.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagementOfExams.Test
{
    [TestClass]
    public class DataStudentTests
    {
        [TestMethod]
        public void TestStudent_With_Consturctor()
        {
            //Arrange
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";
            
            //Act
            Student student = new Student(firstName, lastName, userName, password, emailAdress);

            //Assert
            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(userName, student.UserName);
            Assert.AreEqual(password, student.Password);
            Assert.AreEqual(emailAdress, student.EmailAddress);
        }

        [TestMethod]
        public void TestStudent_WithOut_Consturctor()
        {
            //Arrange
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";

            //Act
            Student student = new Student();

            student.FirstName = firstName;
            student.LastName = lastName;
            student.EmailAddress = emailAdress;
            student.UserName = userName;
            student.Password = password;
            
            //Assert
            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(userName, student.UserName);
            Assert.AreEqual(password, student.Password);
            Assert.AreEqual(emailAdress, student.EmailAddress);

            Assert.AreEqual(student.Grades,null);
            Assert.AreEqual(student.Details,null);
            Assert.AreEqual(student.Exams,null);
        }
    }
}
