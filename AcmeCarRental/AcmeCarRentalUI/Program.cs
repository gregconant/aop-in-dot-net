using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcmeCarRental;
using AcmeCarRental.Entities;

namespace AcmeCarRentalUI {
  class Program {

    private static ILoyaltyDataService _service;

    static void Main(string[] args) {
    
      _service = new FakeLoyaltyDataService();

      SimulateAddingPoints();

      Console.WriteLine("");
      Console.WriteLine(" ***");
      Console.WriteLine("");

      SimulateRemovingPoints();

      Console.WriteLine("");
      Console.WriteLine("");

      Console.ReadKey();
    }

    private static void SimulateAddingPoints() {
      var service = new LoyaltyAccrualService(_service, new ExceptionHandler(), new TransactionManager());
      var rentalAgreement = new RentalAgreement {
        Customer = new Customer {
          Id = Guid.NewGuid(),
          Name = "Some Guy",
          DateOfBirth = new DateTime(1980, 2, 10),
          DriversLicense = "RR123456"
        },
        Vehicle = new Vehicle {
          Id = Guid.NewGuid(),
          Make = "Honda",
          Model = "Accord",
          Size = Size.Compact,
          Vin = "!HABC123"
        },
        StartDate = DateTime.Now.AddDays(-3),
        EndDate = DateTime.Now
      };
      service.Accrue(rentalAgreement);
      //_service.AddPoints(Guid.NewGuid(), 20);


    }

    private static void SimulateRemovingPoints() {
      var service = new LoyaltyRedemptionService(_service, new ExceptionHandler(), new TransactionManager());
      var invoice = new Invoice {
        Customer = new Customer {
          Id = Guid.NewGuid(),
          Name = "Some Other Guy",
          DateOfBirth = new DateTime(1977, 4, 15),
          DriversLicense = "RR009911",

        },
        Vehicle = new Vehicle {
          Id = Guid.NewGuid(),
          Make = "Cadillac",
          Model = "Sedan",
          Size = Size.Luxury,
          Vin = "2BDI"
        },
        CostPerDay = 29.95m,
        Id = Guid.NewGuid()
      };
      service.Redeem(invoice, 3);
    }
  }
}
