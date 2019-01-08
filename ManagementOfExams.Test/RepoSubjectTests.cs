
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
    public class RepoSubjectTests
    {
        
        private Mock<ManagementContext> _mockContext;
        private Repository _subjectRepository;
        private Subject _subject;


      


        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<ManagementContext>();
            _subject = new Subject("FirstName1", 6);

            var data = new List<Subject>
            {
                new Subject("FirstName1",6),
                new Subject("FirstName2", 5)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Subject>>();
            mockSet.As<IQueryable<Subject>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Subject>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Subject>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Subject>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(m => m.Set<Subject>()).Returns(mockSet.Object);

            _subjectRepository = new SubjectRepository(_mockContext.Object);

        }

        
        [TestMethod]
        public void TestCreate()
        {
            var expected = _subjectRepository.GetAll<Subject>();
           
            _subjectRepository.Create(_subject);
            _subjectRepository.Save();

            var actual = _subjectRepository.GetAll<Subject>();

            Assert.AreNotEqual(expected, actual);

        }


       

      
    }


}

