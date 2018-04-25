using GymWizz.Controllers;
using GymWizz.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymWizz.UnitTest.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexReturnView()
        {
            var controller = new HomeController();
            var result = controller.Index();
            Assert.AreEqual(result.GetType().Name, "ViewResult");
        }

        [TestMethod]
        public void TestAboutReturnView()
        {
            var controller = new HomeController();
            var result = controller.About();
            Assert.AreEqual(result.GetType().Name, "ViewResult");
        }

        [TestMethod]
        public void TestContactReturnView()
        {
            var controller = new HomeController();
            var result = controller.Contact();
            Assert.AreEqual(result.GetType().Name, "ViewResult");
        }

        [TestMethod]
        public void TestMainCannotBeforeLogin()
        {
            var controller = new HomeController();
            try
            {
                var result = controller.Main();
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }
    }
}