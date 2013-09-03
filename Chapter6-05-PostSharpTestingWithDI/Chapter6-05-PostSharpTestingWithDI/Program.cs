using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Chapter6_05_PostSharpTestingWithDI {
  class Program {
    static void Main(string[] args) {
      ObjectFactory.Initialize(x => {
                                 x.Scan(scan => {
                                          scan.TheCallingAssembly();
                                          scan.WithDefaultConventions();
                                        });
                               });
      var myObj = ObjectFactory.GetInstance<IMyService>();
      myObj.DoSomething();

      Console.ReadKey();
    }
  }
}
