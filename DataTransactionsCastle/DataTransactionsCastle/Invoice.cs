using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransactionsCastle {
  public class Invoice {
    public Guid Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public List<string> Items { get; set; }

  }
}
