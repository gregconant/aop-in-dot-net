using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace Ch4_AspNetCaching {
  public class CarValueService {
    readonly Random _rand;

    public CarValueService() {
      _rand = new Random();
    }

    public decimal GetValue(int makeId, int conditionId, int year) {
      Thread.Sleep(5000);
      return _rand.Next(10000, 20000);
    }
  }
}