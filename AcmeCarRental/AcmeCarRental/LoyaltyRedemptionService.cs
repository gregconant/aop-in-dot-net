using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using AcmeCarRental.Aspects;
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
    [DefensiveProgrammingAspect]
    [TransactionManagementAspect]
    [ExceptionAspect]
    public void Redeem(Invoice invoice, int numberOfDays) {
      
      // everything unrelated to business logic has been put in the aspect
      var pointsPerDay = 10;
      if (invoice.Vehicle.Size >= Size.Luxury) {
        pointsPerDay = 15;
      }
      var points = numberOfDays * pointsPerDay;

      service.SubtractPoints(invoice.Customer.Id, points);
      invoice.Discount = numberOfDays * invoice.CostPerDay;

    }
  }

}
