using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetPostSharp {
  
  public class TwitterClient {
    [MyInterceptorAspect]
    public void Send(string msg) {
      Console.WriteLine("Sending: {0}", msg);
    }
  }

  class Program {
    static void Main(string[] args) {
      var svc = new TwitterClient();
      svc.Send("hi");
      Console.ReadKey();
    }
  }
}
