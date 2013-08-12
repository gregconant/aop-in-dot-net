using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using AcmeCarRental.Aspects;
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

    [LoggingAspect]
    [DefensiveProgrammingAspect]
    [TransactionManagementAspect]
    [ExceptionAspect]
    public void Accrue(RentalAgreement agreement) {

      // everything unrelated to business logic has been put in the aspect

      var rentalTimeSpan = (agreement.EndDate.Subtract(agreement.StartDate));
      var numberOfDays = (int)Math.Floor(rentalTimeSpan.TotalDays);

      var pointsPerDay = 1;
      if (agreement.Vehicle.Size >= Size.Luxury) {
        pointsPerDay = 2;
      }
      var points = numberOfDays * pointsPerDay;
      service.AddPoints(agreement.Customer.Id, points);

    }
  }
}

// fewer curly braces!