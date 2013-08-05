using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace AcmeCarRental {
  public interface ITransactionManager {
    void Wrapper(Action method);
  }


  public class TransactionManager : ITransactionManager {
    public void Wrapper(Action method) {
      using (var scope = new TransactionScope()) {
        var retries = 3;
        var succeeded = false;
        try {
          while (!succeeded) {
            method();
            scope.Complete();
          }
        }
        catch {
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
