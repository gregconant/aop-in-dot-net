using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopHelloWorldConsole {
  [Serializable]
  public class SomeAspect : OnMethodBoundaryAspect {
    public override void OnEntry(MethodExecutionArgs args)
    {
      Console.WriteLine("Before the method");
      //base.OnEntry(args));
    }
    public override void OnExit(MethodExecutionArgs args) {
      Console.WriteLine("After the method");
    }
  }
}
