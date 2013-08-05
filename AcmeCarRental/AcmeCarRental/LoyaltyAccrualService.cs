using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using AcmeCarRental.Entities;

namespace AcmeCarRental {
  public interface ILoyaltyAccrualService {
    void Accrue(RentalAgreement agreement);
  }

  public class LoyaltyAccrualService : ILoyaltyAccrualService {
    private readonly ILoyaltyDataService service;
    private readonly ITransactionManager transactionManager;

    // constructor getting pretty cluttered
    public LoyaltyAccrualService(ILoyaltyDataService dataService, ITransactionManager transactionManager) {
      this.transactionManager = transactionManager;
      this.service = dataService;
    }

    public void Accrue(RentalAgreement agreement) {

      // defense! defense! defense!
      if (agreement == null) {
        throw new ArgumentNullException("agreement");
      }

      // logging
      Console.WriteLine("Accrue: {0}", DateTime.Now);
      Console.WriteLine("Customer: {0}", agreement.Customer.Id);
      Console.WriteLine("Vehicle: {0}", agreement.Vehicle.Id);

      // use dependencies
       transactionManager.Wrapper(() => {

         var rentalTimeSpan = (agreement.EndDate.Subtract(agreement.StartDate));
         var numberOfDays = (int)Math.Floor(rentalTimeSpan.TotalDays);

         var pointsPerDay = 1;
         if (agreement.Vehicle.Size >= Size.Luxury) {
           pointsPerDay = 2;
         }
         var points = numberOfDays * pointsPerDay;
         service.AddPoints(agreement.Customer.Id, points);

         // logging
         Console.WriteLine("Accrue complete: {0}", DateTime.Now);
       });
    }
  }
}

// fewer curly braces!