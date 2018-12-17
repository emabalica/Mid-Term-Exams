using ManagementOfExams.Controllers;
using ManagementOfExams.Data;
using ManagementOfExams.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<ManagementContext> _mockContext;
        private Repository _teacherRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<ManagementContext>();


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
        public void TestGetById()
        {
            Teacher teacher = new Teacher("FirstName1", "LastName1", "UserName1", "asd1", "mail1@mail.com");
            var actual = _teacherRepository.GetById<Teacher>(teacher.Id);

            Assert.AreEqual(teacher, actual);

        }
        /*
        [TestMethod]
        public void TestCreate()
        {
            int expected = _teacherRepository.GetAll<Teacher>();

            _teacherRepository.Create(new Teacher());

            int actual = _teacherRepository.GetAll<Teacher>().Count();

            Assert.AreEqual(expected, actual);

        }*/
    }
}
