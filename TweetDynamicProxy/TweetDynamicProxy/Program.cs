using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace TweetDynamicProxy {
  public class TwitterClient {
    public virtual void Send(string msg) {
      // note that this method was made Virtual. This is necessary for
      // DynamicProxy interception to work. (At least when intercepting
      // a concrete class. Not necessary for interfaces.)
      Console.WriteLine("Sending: {0}", msg);
    }  

  }

  class Program {
    static void Main(string[] args) {
      var proxyGenerator = new ProxyGenerator();
      //var svc = new TwitterClient();
      var svc = proxyGenerator
        .CreateClassProxy<TwitterClient>(new MyInterceptorAspect());

      svc.Send("hi");
      Console.ReadKey();
    }
  }
}
