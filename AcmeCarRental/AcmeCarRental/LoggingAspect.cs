using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcmeCarRental.Entities;
using PostSharp.Aspects;

namespace AcmeCarRental {
  [Serializable]
  public class LoggingAspect : OnMethodBoundaryAspect {
    public override void OnEntry(MethodExecutionArgs args) {
      Console.WriteLine("{0}: {1}", args.Method.Name, DateTime.Now);

      foreach (var argument in args.Arguments) {
        if (argument != null) {
          if (argument is ILoggable) {
            Console.WriteLine(
              ((ILoggable)argument).LogInformation());
          }
        }

        // This isn't great because the aspect has to know about all of the classes it may have
        // to log, and will require a lot of maintenance as new classes and messages
        // are needed
      }
    }
    public override void OnSuccess(MethodExecutionArgs args) {
      Console.WriteLine("{0} complete: {1}", args.Method.Name, DateTime.Now);
    }
  }
}
