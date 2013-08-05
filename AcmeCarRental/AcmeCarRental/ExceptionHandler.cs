using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCarRental {
  public class ExceptionHandler {
    public static bool Handle(Exception ex) {
      Console.WriteLine("Exception handler doing something");
      return true;
    }
  }
}
