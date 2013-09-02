using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace Chapter6_02_CastleDynamicProxyTesting {
  public class LogInterceptor : IInterceptor {

    public void Intercept(IInvocation invocation) {
      var methodName = invocation.Method.Name;
      Log.Write("Before " + methodName);
      invocation.Proceed();
      Log.Write("After " + methodName);
    }
  }
}
