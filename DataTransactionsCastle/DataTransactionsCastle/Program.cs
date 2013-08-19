using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace DataTransactionsCastle {
  class Program {
    static void Main(string[] args) {
      var proxyGenerator = new ProxyGenerator();

      //var invoiceService = new InvoiceService();
      var invoiceService = proxyGenerator.
        CreateClassProxy<InvoiceService>(new TransactionWithRetries(3));

      var invoice = new Invoice {
        Id = Guid.NewGuid(),
        InvoiceDate = DateTime.Now,
        Items = new List<string> {"Item 1", "Item 2", "Item 3"}
      };
      invoiceService.Save(invoice);
      // invoiceService.SaveRetry(invoice);
      // invoiceService.SaveFail(invoice);
      Console.WriteLine("Save successful");
      Console.ReadKey();
    }
  }
}
