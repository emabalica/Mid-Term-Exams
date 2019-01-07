
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
    public class RepoDetailTests
    {
        
        private Mock<ManagementContext> _mockContext;
        private Repository _detailRepository;
        private Detail _detail;


      


        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<ManagementContext>();
            _detail = new Detail(new DateTime(2011,11,11), new DateTime(2012,12,12),  "FirstName1", 20,11);

            var data = new List<Detail>
            {
                new Detail(new DateTime(2011,11,11), new DateTime(2012,12,12),  "FirstName1", 20,11),
                new Detail(new DateTime(2013, 8, 11), new DateTime(2012, 12, 12), "FirstName2", 5, 7)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Detail>>();
            mockSet.As<IQueryable<Detail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Detail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Detail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Detail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(m => m.Set<Detail>()).Returns(mockSet.Object);

            _detailRepository = new DetailRepository(_mockContext.Object);

        }

        [TestMethod]
        public void TestCreate()
        {
            var expected = _detailRepository.GetAll<Detail>();
           
            _detailRepository.Create(_detail);
            _detailRepository.Save();

            var actual = _detailRepository.GetAll<Detail>();

            Assert.AreNotEqual(expected, actual);

        }


       

      
    }


}

