using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcmeCarRental.Entities;

namespace AcmeCarRental {
  public interface ILoyaltyDataService {
    void AddPoints(Guid customerId, int points);
    void SubtractPoints(Guid Id, int points);
  }

  public class LoyaltyDataService : ILoyaltyDataService {
    public void AddPoints(Guid customerId, int points) {
      throw new NotImplementedException();
    }


    public void SubtractPoints(Guid Id, int points) {
      throw new NotImplementedException();
    }
  }
}
