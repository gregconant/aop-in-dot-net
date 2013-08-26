using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;

namespace Ch4_BaseballStatsPostSharp.Aspects {
  [Serializable]
  public class MyBoundaryAspect : OnMethodBoundaryAspect {
    public override void OnEntry(MethodExecutionArgs args) {
      Console.WriteLine("Before the method");
    }

    public override void OnSuccess(MethodExecutionArgs args) {
      Console.WriteLine("After the method");
    }
  }
}
