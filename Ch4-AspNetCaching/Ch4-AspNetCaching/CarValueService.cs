using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Threading;
using PostSharp.Aspects;

namespace Ch4_AspNetCaching {

  [Serializable]
  public class CarValueCacheAspect : OnMethodBoundaryAspect {
    public override void OnEntry(MethodExecutionArgs args) {
      var key = GetCacheKey(args);
      if (HttpContext.Current.Cache[key] == null) {
        return;
      }
      args.ReturnValue = HttpContext.Current.Cache[key];
                                                // this sets the return value of the bounded method

      args.FlowBehavior = FlowBehavior.Return;  // this makes the bounded method
                                                // return immediately
    }

    public override void OnSuccess(MethodExecutionArgs args) {
      var key = GetCacheKey(args).ToString();
      HttpContext.Current.Cache[key] = args.ReturnValue;
    }

    private string GetCacheKey(MethodExecutionArgs args) {
      var serializedArguments = Serialize(args.Arguments);
      var concatArguments = string.Join("_", serializedArguments);
      concatArguments = args.Method.Name + "_" + concatArguments;
      return concatArguments;
    }

    string[] Serialize(Arguments args) {
      var json = new System.Web.Script.Serialization.JavaScriptSerializer();
      return args.Select(json.Serialize).ToArray();
    }

  }

  public class CarValueService {
    readonly Random _rand;

    public CarValueService() {
      _rand = new Random();
    }

    [CarValueCacheAspect]
    public decimal GetValue(CarValueArgs args) {
//    public decimal GetValue(int makeId, int conditionId, int year) {
      Thread.Sleep(5000);
      return _rand.Next(10000, 20000);
    }
  }

  public struct CarValueArgs {
    public int MakeId { get; set; }
    public int ConditionId { get; set; }
    public int Year { get; set; }
  }
}