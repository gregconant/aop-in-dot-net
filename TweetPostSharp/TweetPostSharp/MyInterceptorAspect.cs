using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;

namespace TweetPostSharp {
  [Serializable]
  public class MyInterceptorAspect : MethodInterceptionAspect {
    public override void OnInvoke(MethodInterceptionArgs args) {
      Console.WriteLine("Interceptor 1");
      args.Proceed(); // this calls the intercepted method
      Console.WriteLine("Interceptor 2");
    }
  }
}
