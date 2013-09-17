using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PostSharp.Aspects;

namespace Ch5_02_AopLazyLoading {
  class Program {
    [LazyLoadGetter]
    static SlowConstructor MyProperty {
      get {
        return new SlowConstructor();
      }
    }
    
    static void Main(string[] args) {
      MyProperty.DoSomething();
      MyProperty.DoSomething();
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
  public class LazyLoadGetter : LocationInterceptionAspect {
    object _backingField;
    object _sync = new object();

    public override void OnGetValue(LocationInterceptionArgs args) {
      if (_backingField == null) {
        lock (_sync) {
          if (_backingField == null) {
            // the first time through, this executes SlowConstructor
            args.ProceedGetValue();
            _backingField = args.Value; 
          }
        }
      }
      args.Value = _backingField;
    }
  }
}
