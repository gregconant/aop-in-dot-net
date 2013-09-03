using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using PostSharp.Aspects;
using StructureMap;

namespace Chapter6_05_PostSharpTestingWithDI {
  [TestFixture]
  public class MyLoggingAspectTest {

    [Test]
    public void Intercept() {
      var mockLoggingService = new Mock<ILoggingService>();
      var args = new MethodExecutionArgs(null, Arguments.Empty);

      ObjectFactory.Initialize(x => 
        x.For<ILoggingService>()
        .Use(mockLoggingService.Object));

      var sut = new MyLoggingAspect();
      // normally PostSharp runs this for us, but that only happens at
      // runtime, so we have to call it manually.
      sut.RuntimeInitialize(null);

      sut.OnEntry(args);
      sut.OnSuccess(args);

      mockLoggingService.Verify(s => s.Write("Log start"));
      mockLoggingService.Verify(s => s.Write("Log end"));
    }
  }
}
