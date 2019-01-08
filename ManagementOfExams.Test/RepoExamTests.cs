
 using System;

using System.Runtime.CompilerServices;
using System.Threading;
using ManagementOfExams.Data;
using ManagementOfExams.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using Moq;

 namespace ManagementOfExams.Test
{
    [TestClass]
    public class RepoStudentTests
    {
        
        private Mock<ManagementContext> _mockContext;
        private Repository _studentRepository;
        private Student _student;


      


        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<ManagementContext>();
            _student = new Student("FirstName1", "LastName1", "UserName1", "asd1", "mail1@mail.com");

            var data = new List<Student>
            {
                new Student("FirstName1", "LastName1", "UserName1", "asd1", "mail1@mail.com"),
                new Student("FirstName2", "LastName2", "UserName2", "asd2", "mail2@mail.com")
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Student>>();
            mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(m => m.Set<Student>()).Returns(mockSet.Object);

            _studentRepository = new StudentRepository(_mockContext.Object);

        }

        
        [TestMethod]
        public void TestCreate()
        {
            var expected = _studentRepository.GetAll<Student>();
           
            _studentRepository.Create(_student);
            _studentRepository.Save();

            var actual = _studentRepository.GetAll<Student>();

            Assert.AreNotEqual(expected, actual);

        }


       

      
    }


}

