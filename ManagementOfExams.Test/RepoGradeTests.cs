
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
    public class RepoGradeTests
    {
        
        private Mock<ManagementContext> _mockContext;
        private Repository _gradeRepository;
        private Grade _grade;


      


        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<ManagementContext>();
            _grade = new Grade(7,new DateTime(2020,12,12));

            var data = new List<Grade>
            {
                new Grade(7,new DateTime(2020,12,12)),
                new Grade(8,new DateTime(2021,12,12))
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Grade>>();
            mockSet.As<IQueryable<Grade>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Grade>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Grade>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Grade>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(m => m.Set<Grade>()).Returns(mockSet.Object);

            _gradeRepository = new GradeRepository(_mockContext.Object);

        }

        
        [TestMethod]
        public void TestCreate()
        {
            var expected = _gradeRepository.GetAll<Grade>();
           
            _gradeRepository.Create(_grade);
            _gradeRepository.Save();

            var actual = _gradeRepository.GetAll<Grade>();

            Assert.AreNotEqual(expected, actual);

        }


       

      
    }


}

