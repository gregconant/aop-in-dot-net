using Chapter6_01_UnitTestingAspects.Controllers;
using System;
using Chapter6_01_UnitTestingAspects.Models;
using System.Web.Mvc;
using System.Web.Security;
using NUnit.Framework;
using System.Linq;

namespace Chapter6_01_UnitTestingAspects.Tests.Controllers {
    
  [TestFixture]
  public class AccountControllerTest {

    [Test]
    public void ChangePassword_Should_Be_Restricted_By_Authorize() {
      var sut = typeof(AccountController);
      var allMethods = sut.GetMethods();
      var changePwdMethods = allMethods.Where(m => m.Name == "ChangePassword");
      foreach (var changePwdMethod in changePwdMethods) {
        var attr = Attribute.GetCustomAttribute(
          changePwdMethod, typeof(AuthorizeAttribute));
        Assert.That(attr, Is.Not.Null);
      }
    }

  }
}
