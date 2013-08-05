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
    private readonly ILoyaltyDataService service;
    private readonly ITransactionManager transactionManager;

    // constructor getting pretty cluttered
    public LoyaltyRedemptionService(ILoyaltyDataService dataService, ITransactionManager transactionManager) {
      this.transactionManager = transactionManager;
      this.service = dataService;
    }

    [LoggingAspect]
    public void Redeem(Invoice invoice, int numberOfDays) {
      // defense! defense! defense!
      if (invoice == null) {
        throw new ArgumentNullException("invoice");
      }
      if (numberOfDays <= 0) {
        throw new ArgumentException("Number of days must be greater than zero.", "numberOfDays");
      }

      // logging has been put in the aspect

      // use dependencies
        transactionManager.Wrapper(() => {
        var pointsPerDay = 10;
        if (invoice.Vehicle.Size >= Size.Luxury) {
          pointsPerDay = 15;
        }
        var points = numberOfDays * pointsPerDay;

        service.SubtractPoints(invoice.Customer.Id, points);
        invoice.Discount = numberOfDays * invoice.CostPerDay;

      });
    }
  }

}
