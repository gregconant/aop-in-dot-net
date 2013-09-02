using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter6_03_CastleAspectTestingWithDependencies {
  public interface IMyService {
    void DoSomething();
  }
  
  public class MyService : IMyService {

    public MyService(IMyOtherService other) {

    }
    public void DoSomething() {
      Console.WriteLine("Service doing something");
    }
  }
}
