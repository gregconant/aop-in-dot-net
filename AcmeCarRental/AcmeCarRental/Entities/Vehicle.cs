using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCarRental.Entities {
  public class Vehicle {
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public Size Size { get; set; }
    public string Vin { get; set; }
  }

  public enum Size
  {
    Undefined = 0,
    Compact,
    Midsize,
    Fullsize,
    Luxury,
    Truck,
    SUV
  }
}
