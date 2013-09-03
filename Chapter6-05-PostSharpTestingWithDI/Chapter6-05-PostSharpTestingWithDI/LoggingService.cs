using System;

namespace Chapter6_05_PostSharpTestingWithDI {
  public interface ILoggingService {
    void Write(string message);
  }

  public class LoggingService : ILoggingService {
    public void Write(string message) {
      Console.Write("Logging: " + message);
    }
  }
}
