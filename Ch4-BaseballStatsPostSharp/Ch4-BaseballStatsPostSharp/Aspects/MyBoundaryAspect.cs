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
      args.MethodExecutionTag = Guid.NewGuid();
    }

    public override void OnSuccess(MethodExecutionArgs args) {
      Console.WriteLine("After the method  {0}", args.MethodExecutionTag);
    }
  }
}
