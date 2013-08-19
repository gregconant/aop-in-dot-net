using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UIThreadingExample {
  public class TwitterService {
    public string GetTweet() {
      Thread.Sleep(3000);
      return "Tweet from " + DateTime.Now.TimeOfDay;
    }
  }
}
