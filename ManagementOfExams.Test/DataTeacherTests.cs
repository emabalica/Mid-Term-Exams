using System;
using ManagementOfExams.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagementOfExams.Test
{
    [TestClass]
    public class DataTeacherTests
    {
        [TestMethod]
        public void TestTeacher_With_Consturctor()
        {
            //Arrange
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";
            
            //Act
            Teacher teacher = new Teacher(firstName, lastName, userName, password, emailAdress);

            //Assert
            Assert.AreEqual(firstName,teacher.FirstName);
            Assert.AreEqual(lastName, teacher.LastName);
            Assert.AreEqual(userName, teacher.UserName);
            Assert.AreEqual(password,teacher.Password);
            Assert.AreEqual(emailAdress,teacher.EmailAddress);
        }

        [TestMethod]
        public void TestTeacher_WithOut_Consturctor()
        {
            //Arrange
            string firstName = "TestF";
            string lastName = "TestL";
            string userName = "TestU";
            string password = "TestP";
            string emailAdress = "TestE";
            
            //Act
            Teacher teacher = new Teacher();

            teacher.FirstName = firstName;
            teacher.LastName = lastName;
            teacher.EmailAddress = emailAdress;
            teacher.UserName = userName;
            teacher.Password = password;
            Subject s = new Subject();
            teacher.Subject = s; 

            //Assert
            Assert.AreEqual(firstName, teacher.FirstName);
            Assert.AreEqual(lastName, teacher.LastName);
            Assert.AreEqual(userName, teacher.UserName);
            Assert.AreEqual(password, teacher.Password);
            Assert.AreEqual(emailAdress, teacher.EmailAddress);
            Assert.AreEqual(s,teacher.Subject);
        }

    }
}
