using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCarRental.Entities {
  public class Invoice : ILoggable {
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public decimal CostPerDay { get; set; }
    public decimal Discount { get; set; }


    public string LogInformation() {
      return String.Format("Invoice: {0}", Id);
    }
  }
}
