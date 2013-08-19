using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PostSharp.Aspects;

namespace UIThreadingExample.Aspects {
  [Serializable]
  public class WorkerThread : MethodInterceptionAspect {
    public override void OnInvoke(MethodInterceptionArgs args) {
      var thread = new Thread(args.Proceed); // pass the intercepted method to the worker thread!
      thread.Start();

      // we could also use Task here, but that isn't really relevant to the example.
    }
  }
}
