using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Chapter6_01_UnitTestingAspects;
using Chapter6_01_UnitTestingAspects.Controllers;
using NUnit.Framework;

namespace Chapter6_01_UnitTestingAspects.Tests.Controllers {
  [TestFixture]
  public class HomeControllerTest {
    [Test]
    public void Index() {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
    }

    [Test]
    public void About() {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.About() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }
  }
}
