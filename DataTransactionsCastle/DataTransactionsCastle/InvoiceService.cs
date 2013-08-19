using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataTransactionsCastle {
  public class InvoiceService {
    public virtual void Save(Invoice invoice) {
      
    }


    private bool _isRetry;
    public virtual void SaveRetry(Invoice invoice) {
      if (_isRetry) {
        _isRetry = true;
        throw new DataException(); // fails the first time
      }
    }

    public virtual void SaveFail(Invoice invoice) {
      throw new DataException();
    }
  }
}
