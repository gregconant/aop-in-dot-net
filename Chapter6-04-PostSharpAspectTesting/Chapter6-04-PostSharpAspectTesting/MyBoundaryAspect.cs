using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;

namespace Chapter6_04_PostSharpAspectTesting {
  [Serializable]
  public class MyBoundaryAspect : OnMethodBoundaryAspect {
    public override void OnEntry(MethodExecutionArgs args) {
      Log.Write("Before: " + args.Method.Name);
    }
    public override void OnSuccess(MethodExecutionArgs args) {
      Log.Write("Success: " + args.Method.Name);
    }
  }
}
