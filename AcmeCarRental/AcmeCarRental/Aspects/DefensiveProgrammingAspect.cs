using System;
using PostSharp.Aspects;

namespace AcmeCarRental.Aspects {
  [Serializable]
  class DefensiveProgrammingAspect : OnMethodBoundaryAspect {
    public override void OnEntry(MethodExecutionArgs args) {
      var parameters = args.Method.GetParameters();
      var arguments = args.Arguments;
      for (int i = 0; i < arguments.Count; i++) {
        if (arguments[i] == null) {
          // don't have to know the name of the parameter, so you're
          // protected if it changes
          throw new ArgumentNullException(parameters[i].Name);
        }
        if (arguments[i] is int && (int)arguments[i] <= 0) {
          throw new ArgumentException("", parameters[i].Name);
        }
      }
    }
  }
}
