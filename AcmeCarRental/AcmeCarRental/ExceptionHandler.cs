using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCarRental {

  public static class ExceptionHandler {
    public static bool Handle(Exception ex) {
      Console.WriteLine("Exception handler handling exception {0}", ex.Message);
      return true;
    }
  }
}
