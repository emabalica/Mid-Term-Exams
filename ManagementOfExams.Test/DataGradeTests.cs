using System;
using ManagementOfExams.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagementOfExams.Test
{
    [TestClass]
    public class DataGradeTests
    {
        [TestMethod]
        public void TestGrade_With_Consturctor()
        {
            //Arrange
            
            int value = 7;
            DateTime date=new DateTime(2017,8,5); 

            //Act
            Grade grade = new Grade(value,date);

            //Assert
            Assert.AreEqual(value, grade.Value);
            Assert.AreEqual(date, grade.Date);
        }

        [TestMethod]
        public void TestGrade_WithOut_Consturctor()
        {
            //Arrange

            int value = 7;
            DateTime date = new DateTime(2017, 8, 5);
            //Act

            Grade grade = new Grade();

            grade.Value = value;
            grade.Date = date;

           //Assert
            Assert.AreEqual(grade.Exam, null);
            Assert.AreEqual(grade.Student, null);
           }

    }
}
