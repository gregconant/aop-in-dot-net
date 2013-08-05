﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcmeCarRental.Entities;

namespace AcmeCarRental {
  public interface ILoyaltyAccrualService {
    void Accrue(RentalAgreement agreement);
  }

  public class LoyaltyAccrualService : ILoyaltyAccrualService {
    private readonly ILoyaltyDataService _loyaltyDataService;

    public LoyaltyAccrualService(ILoyaltyDataService service)
    {
      _loyaltyDataService = service;

    }

    public void Accrue(RentalAgreement agreement) {
      // logging
      Console.WriteLine("Accrue: {0}", DateTime.Now);
      Console.WriteLine("Customer: {0}", agreement.Customer.Id);
      Console.WriteLine("Vehicle: {0}", agreement.Vehicle.Id);

      var rentalTimeSpan = (agreement.EndDate.Subtract(agreement.StartDate));
      var numberOfDays = (int) Math.Floor(rentalTimeSpan.TotalDays);

      var pointsPerDay = 1;
      if (agreement.Vehicle.Size >= Size.Luxury) {
        pointsPerDay = 2;
      }
      var points = numberOfDays*pointsPerDay;
      _loyaltyDataService.AddPoints(agreement.Customer.Id, points);
      
      // logging
      Console.WriteLine("Accrue complete: {0}", DateTime.Now);
    }
  }


}