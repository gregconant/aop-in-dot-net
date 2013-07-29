using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcmeCarRental.Entities;

namespace AcmeCarRental {
  public interface ILoyaltyAccrualService {
    void Accrue(RentalAgreement agreement);
  }

 
}
