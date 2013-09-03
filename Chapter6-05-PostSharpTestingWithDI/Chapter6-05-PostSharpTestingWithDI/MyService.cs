using System;

namespace Chapter6_05_PostSharpTestingWithDI {
  public interface IMyService {
    void DoSomething();
  }
  
  public class MyService : IMyService {

    public MyService(IMyOtherService other) {

    }

    [MyLoggingAspect]
    public void DoSomething() {
      Console.WriteLine("Service doing something");
    }
  }
}
