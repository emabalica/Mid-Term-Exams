using System;
using System.Diagnostics;
using ManagementOfExams.Controllers;
using ManagementOfExams.Data;
using ManagementOfExams.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;


namespace ManagementOfExams.Test
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Home_Controller_Test()
        {
            //Arrange
            HomeController controllerUnderTest = new HomeController();
            //Act
            var resultAbout = controllerUnderTest.About() as ViewResult;
            var resultIndex = controllerUnderTest.Index() as ViewResult;
            var resultContact = controllerUnderTest.Contact() as ViewResult;
            var resultPrivacy = controllerUnderTest.Privacy() as ViewResult;
            
            //Assert
            Assert.AreEqual(null,resultAbout.ViewName);
            Assert.AreEqual(null, resultIndex.ViewName);
            Assert.AreEqual(null, resultContact.ViewName);
            Assert.AreEqual(null, resultPrivacy.ViewName);
        }
    }
}
