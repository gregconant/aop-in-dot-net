using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;
using StructureMap;

namespace Chapter6_05_PostSharpTestingWithDI {

  public class MyNormalCode {
    [MyThinAspect]
    public string Reverse(string str) {
      return new string(str.Reverse().ToArray());
    }
  }

  public static class AspectSettings {
    public static bool On = true;
  }

  [Serializable]
  public class MyThinAspect : OnMethodBoundaryAspect {
    private IMyCrossCuttingConcern _concern;

    public override void RuntimeInitialize(System.Reflection.MethodBase method) {
      if (!AspectSettings.On) {
        return;
      }
      _concern = ObjectFactory.GetInstance<IMyCrossCuttingConcern>();
    }

    public override void OnEntry(MethodExecutionArgs args) {
      if (!AspectSettings.On) {
        return;
      }
      _concern.BeforeMethod("before");
    }

    public override void OnSuccess(MethodExecutionArgs args) {
      if (!AspectSettings.On) {
        return;
      }
      _concern.AfterMethod("after");
    }
  }

  public interface IMyCrossCuttingConcern {
    void BeforeMethod(string str);
    void AfterMethod(string str);
  }

  public class MyCrossCuttingConcern : IMyCrossCuttingConcern {
    private ILoggingService _logService;

    public void BeforeMethod(string str) {
      _logService.Write(str);
    }

    public void AfterMethod(string str) {
      _logService.Write(str);
    }

  }
}
