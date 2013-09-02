using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PostSharp.Aspects;

namespace Ch5_01_BasicLocationInterception {
  public class SomeClass {
    [MyLocationAspect]
    public string MyProperty { get; set; }

    public Lazy<SlowConstructor> SlowProperty = new Lazy<SlowConstructor>(() => new SlowConstructor());

    
  }

  [Serializable]
  public class MyLocationAspect : LocationInterceptionAspect {
    public override void OnSetValue(LocationInterceptionArgs args) {
      Console.WriteLine("Hello from the aspect!");
      args.ProceedGetValue(); // continue with set
    }
  }

  class Program {
    static void Main(string[] args) {
      var obj = new SomeClass();
      obj.MyProperty = "some string";
      Console.ReadKey();

    }
  }

  public class SlowConstructor {
    public SlowConstructor() {
      Thread.Sleep(2000);
    }
  }
}
