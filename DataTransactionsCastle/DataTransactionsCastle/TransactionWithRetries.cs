using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;

namespace DataTransactionsCastle {
  public class TransactionWithRetries : IInterceptor {
    public void Intercept(IInvocation invocation) {
      //var trans = new TransactionScope();
      using (var trans = new TransactionScope()) {
        invocation.Proceed();
        trans.Complete();
      }

    }
  }
}
