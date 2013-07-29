using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCarRental {
  public interface ILoyaltyAccrualService {
    void Accrue(RentalAgreement agreement);
  }

 
}
