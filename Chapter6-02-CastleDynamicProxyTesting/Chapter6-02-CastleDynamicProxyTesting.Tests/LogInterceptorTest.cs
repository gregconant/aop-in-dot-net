using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Castle.DynamicProxy;
using Moq;

namespace Chapter6_02_CastleDynamicProxyTesting.Tests {
  [TestFixture]
  public class LogInterceptorTest {

    [Test]
    public void TestIntercept() {
      var myInterceptor = new LogInterceptor();

      Mock<IInvocation> invocationMock = new Mock<IInvocation>();
      invocationMock.Setup(i => i.Method.Name).Returns("SomeMethod");

      var invocation = invocationMock.Object;

      myInterceptor.Intercept(invocation);

      Assert.IsTrue(Log.Messages.Contains("Before " + invocation.Method.Name));
      Assert.IsTrue(Log.Messages.Contains("After " + invocation.Method.Name));
    }
  }
}
