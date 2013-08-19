using System;
using System.Windows.Forms;
using PostSharp.Aspects;

namespace UIThreadingExample.Aspects {
  [Serializable]
  public class UIThread : MethodInterceptionAspect {
    public override void OnInvoke(MethodInterceptionArgs args) {
      // we need the instance that has the method we're intercepting,
      // so we can find out what thread it's on (to tell whether Invoke is Required or not).
      var form = (Form) args.Instance;
      if (form.InvokeRequired) {
        form.Invoke(new Action(() => args.Proceed()));
      }
      else {
        args.Proceed();
      }
    }

  }
}
