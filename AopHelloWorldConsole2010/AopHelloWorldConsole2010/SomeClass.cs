using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopHelloWorldConsole {
  public class SomeClass {
    [SomeAspect]
    public void SomeMethod() {
      Console.WriteLine("Hello, PostSharp!");
    }
  }
}
