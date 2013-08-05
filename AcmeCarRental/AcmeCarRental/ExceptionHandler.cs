using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCarRental {
  public interface IExceptionHandler {
    void Wrapper(Action method);
  }

  public class ExceptionHandler : IExceptionHandler {
    public void Wrapper(Action method) {
      try {
        method();
      }
      catch (Exception ex) {
        Console.WriteLine("Exception handler handling exception {0}", ex.Message);
      }
    }
  }
}
