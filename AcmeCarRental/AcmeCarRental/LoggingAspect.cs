using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;

namespace AcmeCarRental {
  [Serializable]
  public class LoggingAspect : OnMethodBoundaryAspect {
    public override void OnEntry(MethodExecutionArgs args) {
      Console.WriteLine("{0}: {1}", args.Method.Name, DateTime.Now);
    }
    public override void OnSuccess(MethodExecutionArgs args) {
      Console.WriteLine("{0} complete: {1}", args.Method.Name, DateTime.Now);
    }
  }
}
