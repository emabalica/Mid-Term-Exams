
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
    public class RepoExamTests
    {
        
        private Mock<ManagementContext> _mockContext;
        private Repository _examRepository;
        private Exam _exam;


      


        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<ManagementContext>();
            _exam = new Exam("FirstName1", "LastName1", new DateTime(2011,11,11), new DateTime(2012, 12, 12));

            var data = new List<Exam>
            {
                new Exam("FirstName1", "LastName1", new DateTime(2011,11,11), new DateTime(2012, 12, 12)),
                new Exam("FirstName2", "LastName2", new DateTime(2011, 11, 11), new DateTime(2012, 12, 12))
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Exam>>();
            mockSet.As<IQueryable<Exam>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Exam>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Exam>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Exam>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(m => m.Set<Exam>()).Returns(mockSet.Object);

            _examRepository = new ExamRepository(_mockContext.Object);

        }

        
        [TestMethod]
        public void TestCreate()
        {
            var expected = _examRepository.GetAll<Exam>();
           
            _examRepository.Create(_exam);
            _examRepository.Save();

            var actual = _examRepository.GetAll<Exam>();

            Assert.AreNotEqual(expected, actual);

        }


       

      
    }


}

