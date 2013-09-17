using PostSharp.Aspects;
using System;
using StructureMap;

namespace Chapter6_05_PostSharpTestingWithDI {

  [Serializable]
  public class MyLoggingAspect : OnMethodBoundaryAspect {
    [NonSerialized]
    private ILoggingService _loggingService;

    public override void RuntimeInitialize(System.Reflection.MethodBase method) {
      _loggingService = ObjectFactory.GetInstance<ILoggingService>();
    }

    public override void OnEntry(MethodExecutionArgs args) {
      _loggingService.Write("Log start");
    }
    
    public override void OnSuccess(MethodExecutionArgs args) {
      _loggingService.Write("Log end");
    }
  }
}
