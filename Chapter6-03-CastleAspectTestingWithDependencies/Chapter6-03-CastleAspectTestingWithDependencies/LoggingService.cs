using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter6_03_CastleAspectTestingWithDependencies {
  public interface ILoggingService {
    void Write(string message);
  }

  public class LoggingService : ILoggingService {
    public void Write(string message) {
      Console.Write("Logging: " + message);
    }
  }
}
