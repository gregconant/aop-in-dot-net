using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using PostSharp.Aspects;

namespace AcmeCarRental.Aspects {
  [Serializable]
  public class TransactionManagementAspect : MethodInterceptionAspect {
    public override void OnInvoke(MethodInterceptionArgs args) {
      // start new transaction
      using (var scope = new TransactionScope()) {
        var retries = 3;
        var succeeded = false;
        while (!succeeded) {
          try {
            args.Proceed(); // <----   this proceeds to the intercepted method
            scope.Complete();
            succeeded = true;
          }
          catch (Exception ex) {
            // don't rethrow until retry limit is reached
            if (retries >= 0) {
              retries = retries - 1;
            }
            else {
                throw;
            }
          }
        }
      }
    }


  }
}
