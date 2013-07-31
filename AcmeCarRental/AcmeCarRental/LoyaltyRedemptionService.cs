using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
      var pointsPerDay = 10;
      if (invoice.Vehicle.Size >= Size.Luxury) {
        pointsPerDay = 15;
      }
      var points = numberOfDays*pointsPerDay;

      _service.SubtractPoints(invoice.Customer.Id, points);
      invoice.Discount = numberOfDays*invoice.CostPerDay;

    }
  }
}
