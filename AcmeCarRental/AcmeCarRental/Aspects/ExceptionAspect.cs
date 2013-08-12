using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;

namespace AcmeCarRental.Aspects {
  [Serializable]
  class ExceptionAspect : OnExceptionAspect {
    public override void OnException(MethodExecutionArgs args) {
      if (ExceptionHandler.Handle(args.Exception)) {
        args.FlowBehavior = FlowBehavior.Continue;
        // Flow Behavior: specify what you want to happen once the
        // aspect is done
        // Default for this aspect is RethrowException.
        // Other options:
        //  Default
        //  Return
        //  Throw Exception
        
        
      }
    }
  }
}
