using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PostSharp.Aspects;

namespace Ch5_03_AopLazyLoadingFields {
  class Program {
    [LazyLoadActivator]
    static SlowConstructor MyField;
    
    static void Main(string[] args) {
      MyField.DoSomething();
      MyField.DoSomething();
      Console.ReadKey();
    }
  }

  public class SlowConstructor {
    public SlowConstructor() {
      Console.WriteLine("This takes a while...");
      Thread.Sleep(5000);
    }
    public void DoSomething() {
      Console.WriteLine("It's {0}", DateTime.Now);

    }
  }

  [Serializable]
  public class LazyLoadActivator : LocationInterceptionAspect {
    object _backingField;
    object _sync = new object();

    public override void OnGetValue(LocationInterceptionArgs args) {
      if (_backingField == null) {
        lock (_sync) {
          if (_backingField == null) {
            // create new instance of this field on the fly
            _backingField = Activator.CreateInstance(args.Location.LocationType);
          }
        }
      }
      args.Value = _backingField;
    }
  }
}
