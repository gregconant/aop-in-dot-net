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
    private readonly ILoyaltyDataService _loyaltyDataService;

    public LoyaltyAccrualService(ILoyaltyDataService service) {
      _loyaltyDataService = service;

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

      try {

        // start transaction
        using (var scope = new TransactionScope()) {
          var retries = 3;
          var succeeded = false;
          while (!succeeded) {

            try {

              var rentalTimeSpan = (agreement.EndDate.Subtract(agreement.StartDate));
              var numberOfDays = (int) Math.Floor(rentalTimeSpan.TotalDays);

              var pointsPerDay = 1;
              if (agreement.Vehicle.Size >= Size.Luxury) {
                pointsPerDay = 2;
              }
              var points = numberOfDays*pointsPerDay;
              _loyaltyDataService.AddPoints(agreement.Customer.Id, points);

              //transactions
              scope.Complete();
              succeeded = true;

              // logging
              Console.WriteLine("Accrue complete: {0}", DateTime.Now);
            }
            catch {
              // don't rethrow until retry limit is reached
              if (retries >= 0) {
                retries = retries - 1;
              }
              else {
                throw; // no Complete -- this will roll back the whole transaction
              }
            }
          }
        }
      } // end outer try
      catch (Exception ex) {
        if (!ExceptionHandler.Handle(ex))
          throw;
      }
    }
  }
}
// so many curly braces! }}}}}}}}}