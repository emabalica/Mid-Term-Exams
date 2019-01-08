
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
    public class RepoTests
    {
        
        private Mock<ManagementContext> _mockContext;
        private Repository _teacherRepository;
        private Teacher _teacher;


      


        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<ManagementContext>();
            _teacher = new Teacher("FirstName1", "LastName1", "UserName1", "asd1", "mail1@mail.com");

            var data = new List<Teacher>
            {
                new Teacher("FirstName1", "LastName1", "UserName1", "asd1", "mail1@mail.com"),
                new Teacher("FirstName2", "LastName2", "UserName2", "asd2", "mail2@mail.com")
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Teacher>>();
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Teacher>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(m => m.Set<Teacher>()).Returns(mockSet.Object);

            _teacherRepository = new TeacherRepository(_mockContext.Object);

        }

        
        [TestMethod]
        public void TestCreate()
        {
            var expected = _teacherRepository.GetAll<Teacher>();
           
            _teacherRepository.Create(_teacher);
            _teacherRepository.Save();

            var actual = _teacherRepository.GetAll<Teacher>();

            Assert.AreNotEqual(expected, actual);

        }


        [TestMethod]
        public void TestUpdate()
        {
            var expected = _teacherRepository.GetAll<Teacher>();
            Teacher teacher= new Teacher("FirstName1", "LastName1", "UserName1", "asd1", "mail1@mail.com");
            teacher.Id = _teacher.Id;
            
            _teacherRepository.Update(teacher);
            _teacherRepository.Save();

            var actual = _teacherRepository.GetAll<Teacher>();

            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void TestDelete()
        {
            var expected = _teacherRepository.GetAll<Teacher>();
            Guid id = _teacher.Id;
            var teacher = _teacherRepository.GetById<Teacher>(id);
            _teacherRepository.Delete(_teacher);
            _teacherRepository.Save();

            var actual = _teacherRepository.GetAll<Teacher>();

            Assert.AreNotEqual(expected, actual);

        }

      
    }


}

