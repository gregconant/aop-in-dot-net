using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopHelloWorldConsole {
  class Program {
    static void Main(string[] args)
    {
      var c = new SomeClass();
      // something will be done before and after SomeMethod is called.
      c.SomeMethod();
      Console.ReadKey();

    }
  }
}
