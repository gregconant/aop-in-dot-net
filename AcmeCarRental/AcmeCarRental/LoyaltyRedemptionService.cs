using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using AcmeCarRental.Entities;

namespace AcmeCarRental {
  public interface ILoyaltyRedemptionService {
    void Redeem(Invoice invoice, int numberOfDays);
  }

  public class LoyaltyRedemptionService : ILoyaltyRedemptionService {
    private readonly ILoyaltyDataService _service;

    public LoyaltyRedemptionService(ILoyaltyDataService service) {
      _service = service;
    }

    public void Redeem(Invoice invoice, int numberOfDays) {
      // defense! defense! defense!
      if (invoice == null) {
        throw new ArgumentNullException("invoice");
      }
      if (numberOfDays <= 0) {
        throw new ArgumentException("Number of days must be greater than zero.", "numberOfDays");
      }

      // logging
      Console.WriteLine("Redeem: {0}", DateTime.Now);
      Console.WriteLine("Invoice: {0}", invoice.Id);

      try {


        // start new transaction
        using (var scope = new TransactionScope()) {
          var retries = 3;
          var succeeded = false;
          while (!succeeded) {

            try {

              var pointsPerDay = 10;
              if (invoice.Vehicle.Size >= Size.Luxury) {
                pointsPerDay = 15;
              }
              var points = numberOfDays*pointsPerDay;

              _service.SubtractPoints(invoice.Customer.Id, points);
              invoice.Discount = numberOfDays*invoice.CostPerDay;

              scope.Complete();
              succeeded = true;

              // logging
              Console.WriteLine("Redeem complete: {0}", DateTime.Now);
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
      } // end outer try
      catch (Exception ex) {
        if (!ExceptionHandler.Handle(ex))
        {
          throw ex;
        }
      }
    }
  }
}
