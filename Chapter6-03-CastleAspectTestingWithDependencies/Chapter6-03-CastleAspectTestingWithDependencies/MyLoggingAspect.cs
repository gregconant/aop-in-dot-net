using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace Chapter6_03_CastleAspectTestingWithDependencies {
  public class MyLoggingAspect : IInterceptor {
    private readonly ILoggingService _loggingService;

    public MyLoggingAspect(ILoggingService service) {
      _loggingService = service;

    }
    public void Intercept(IInvocation invocation) {
      _loggingService.Write("Log start");
      invocation.Proceed();
      _loggingService.Write("Log stop");

    }
  }
}
