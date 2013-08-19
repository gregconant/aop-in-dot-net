using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace TweetDynamicProxy {
  public class MyInterceptorAspect : IInterceptor {
    public void Intercept(IInvocation invocation) {
      Console.WriteLine("Interceptor Message 1");
      invocation.Proceed();
      Console.WriteLine("Interceptor Message 2");

    }
  }
}
