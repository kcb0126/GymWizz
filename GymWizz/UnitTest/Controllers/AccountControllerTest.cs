using GymWizz.Controllers;
using GymWizz.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Spring.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace GymWizz.UnitTest.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void TestReturnUrlBeforeLogin()
        {
            var controller = new AccountController();
            var redirectUrl = "https://google.com";
            var result = controller.Login(redirectUrl) as ViewResult;
            Assert.AreEqual(redirectUrl, result.ViewData["ReturnUrl"]);
        }

        //[TestMethod]
        public void TestRedirectUrlAfterLogin()
        {
            //// Arrange
            //var appmockContext = new Mock<IApplicationContext>();
            //var mgmtmockContext = new Mock<IManagementService>();

            //var controller = new AccountController();
            //var model = new LoginViewModel { Email = "user@domain.com", Password = "Pass1234!", RememberMe = false };
            //var task4result = controller.Login(model, null);
            //var result = task4result.Result as ViewResult;
        }

        [TestMethod]
        public void TestRegisterMatchingGymId()
        {
            var controller = new AccountController();
            int gymId = 0;
            var result = controller.Register(gymId) as ViewResult;
            Assert.AreEqual(result.ViewBag.GymId, gymId);
        }

        [TestMethod]
        public void TestRegisterGymList()
        {
            var controller = new AccountController();
            var result = controller.Register(0) as ViewResult;
            Assert.AreEqual(result.ViewBag.Gyms.GetType().Name, "SelectList");
        }
    }
}