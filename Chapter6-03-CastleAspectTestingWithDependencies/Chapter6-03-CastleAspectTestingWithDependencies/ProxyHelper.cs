using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using StructureMap;

namespace Chapter6_03_CastleAspectTestingWithDependencies {
  public class ProxyHelper {
    readonly ProxyGenerator _proxyGenerator;

    public ProxyHelper() {
      _proxyGenerator = new ProxyGenerator();
    }
    public object Proxify<T, K>(object obj) where K : IInterceptor {
      // use StructureMap to handle the aspect's dependencies
      var interceptor = (IInterceptor)ObjectFactory.GetInstance<K>();
      var result = _proxyGenerator
              .CreateInterfaceProxyWithTargetInterface(
              typeof(T), obj, interceptor);
      return result;
    }
  }
}
