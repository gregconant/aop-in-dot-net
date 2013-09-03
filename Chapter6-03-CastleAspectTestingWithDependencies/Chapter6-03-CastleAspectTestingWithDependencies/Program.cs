using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using Castle.DynamicProxy;

namespace Chapter6_03_CastleAspectTestingWithDependencies {
  class Program {
    static void Main(string[] args) {

      // Here, StructureMap figures out our dependencies.
      ObjectFactory.Initialize(x =>
        {
          x.Scan(scan => {
            scan.TheCallingAssembly();
            scan.WithDefaultConventions();
          });
          var proxyHelper = new ProxyHelper();
          
          x.For<IMyService>().Use<MyService>()
            .EnrichWith(proxyHelper.Proxify<IMyService, MyLoggingAspect>);
          // this makes StructureMap's ObjectFactory
          // use the ProxyHelper to apply the aspect to the instance the
          // factory creates
        });
      

      var myObj = ObjectFactory.GetInstance<IMyService>();
      myObj.DoSomething();

      Console.ReadKey();
    
    }
  }
}
