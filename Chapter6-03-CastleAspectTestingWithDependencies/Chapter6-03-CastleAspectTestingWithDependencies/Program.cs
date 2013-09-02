using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter6_03_CastleAspectTestingWithDependencies {
  class Program {
    static void Main(string[] args) {
      var myOtherObj = new MyOtherService();
      var myObj = new MyService(myOtherObj);
      myObj.DoSomething();

      Console.ReadKey();
    
    }
  }
}
