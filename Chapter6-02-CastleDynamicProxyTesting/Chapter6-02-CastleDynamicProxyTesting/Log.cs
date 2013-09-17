using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter6_02_CastleDynamicProxyTesting {
  public static class Log {
    public static List<string> _messages = new List<string>();
    public static List<string> Messages {
      get { return _messages; }
    }

    public static void Write(string message) {
      _messages.Add(message);
    }
  }
}
