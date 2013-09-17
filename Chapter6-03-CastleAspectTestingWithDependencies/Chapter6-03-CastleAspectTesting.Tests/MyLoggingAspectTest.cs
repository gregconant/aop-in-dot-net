using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Chapter6_03_CastleAspectTestingWithDependencies;
using Moq;
using Castle.DynamicProxy;

namespace Chapter6_03_CastleAspectTesting.Tests {
  [TestFixture]
  public class MyLoggingAspectTest {

    [Test]
    public void Intercept_CallsLoggingService() {
      var mockLoggingService = new Mock<ILoggingService>();

      var loggingAspect = new MyLoggingAspect(mockLoggingService.Object);

      var mockInvocation = new Mock<IInvocation>();

      loggingAspect.Intercept(mockInvocation.Object);

      mockLoggingService.Verify(s => s.Write("Log start"));
      mockLoggingService.Verify(s => s.Write("Log end"));
    }
  }
}
