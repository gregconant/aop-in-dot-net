using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter6_03_CastleAspectTestingWithDependencies {
  public interface IMyOtherService {
    void DoOtherThing();
  }
  
  public class MyOtherService : IMyOtherService {
    public void DoOtherThing() {
      // lied, not actually doing anything.
    }
  }
}
