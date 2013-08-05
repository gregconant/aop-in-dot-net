using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCarRental.Entities {

  public class RentalAgreement : ILoggable {
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string LogInformation() {
      return String.Format("Customer: {0}\r\nVehicle: {1}", Customer.Id, Vehicle.Id);
    }
  }
}
