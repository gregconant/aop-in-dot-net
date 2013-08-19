using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;

namespace DataTransactionsCastle {
  public class TransactionWithRetries : IInterceptor {
    private readonly int _maxRetries;

    public TransactionWithRetries(int maxRetries) {
      _maxRetries = maxRetries;

    }
    public void Intercept(IInvocation invocation) {
      //var trans = new TransactionScope();
      var succeeded = false;
      var retries = _maxRetries;
      while (!succeeded) {

        using (var trans = new TransactionScope()) {
          try {
            invocation.Proceed();
            trans.Complete();
            succeeded = true;
          }
          catch (Exception) {
            if (retries >= 0) {
              Console.WriteLine("Retrying {0}", invocation.Method.Name);
              retries--;
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
