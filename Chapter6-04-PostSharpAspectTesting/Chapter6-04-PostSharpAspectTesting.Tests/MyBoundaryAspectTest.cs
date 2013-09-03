using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PostSharp.Aspects;
using System.Reflection.Emit;

namespace Chapter6_04_PostSharpAspectTesting.Tests {
  [TestFixture]
  public class MyBoundaryAspectTest {

    [Test]
    public void TestMyBoundaryAspect() {
      var args = new MethodExecutionArgs(null, Arguments.Empty);
      args.Method = new DynamicMethod("FooBar", null, null);
      var aspect = new MyBoundaryAspect();
      aspect.OnEntry(args);

      aspect.OnSuccess(args);
      Assert.IsTrue(Log.Messages.Contains("Before: FooBar"));
      Assert.IsTrue(Log.Messages.Contains("Success: FooBar"));
    }
  }
}
