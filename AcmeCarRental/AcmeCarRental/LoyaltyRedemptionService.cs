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
    private readonly IExceptionHandler exceptionHandler;
    private readonly ITransactionManager transactionManager;

    public LoyaltyRedemptionService(ILoyaltyDataService dataService, IExceptionHandler exceptionHandler, ITransactionManager transactionManager) {
      this.transactionManager = transactionManager;
      this.exceptionHandler = exceptionHandler;
      this.service = dataService;
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

      // use dependencies
      exceptionHandler.Wrapper(() => 
        transactionManager.Wrapper(() => {
        var pointsPerDay = 10;
        if (invoice.Vehicle.Size >= Size.Luxury) {
          pointsPerDay = 15;
        }
        var points = numberOfDays * pointsPerDay;

        service.SubtractPoints(invoice.Customer.Id, points);
        invoice.Discount = numberOfDays * invoice.CostPerDay;

        // logging
        Console.WriteLine("Redeem complete: {0}", DateTime.Now);

      }));
    }
  }

}
