using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using PostSharp.Aspects;

namespace Ch4_AspNetCaching {

  public class CarValueCacheAspect : OnMethodBoundaryAspect {
    public override void OnSuccess(MethodExecutionArgs args) {
      var key = GetCacheKey(args).ToString();
      HttpContext.Current.Cache[key] = args.ReturnValue;
    }

    private object GetCacheKey(MethodExecutionArgs args) {
      // to get a unique key, we join all arguments into one string
      var concatArguments = string.Join("_", args.Arguments);
      concatArguments = args.Method.Name + "_" + concatArguments;
      return concatArguments;
    }

  }

  public class CarValueService {
    readonly Random _rand;

    public CarValueService() {
      _rand = new Random();
    }

    [CarValueCacheAspect]
    public decimal GetValue(int makeId, int conditionId, int year) {
      Thread.Sleep(5000);
      return _rand.Next(10000, 20000);
    }
  }
}