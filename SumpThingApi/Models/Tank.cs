using System;
using System.Collections.Generic;

namespace SumpThingApi.Models {
  public class Tank {
    public int Id { get; set; }
    public string Name { get; set; }
    public string WaterType { get; set; }
    public string TankType { get; set; }
    public int Volume { get; set; }
    public string VolumeUnit { get; set; }
    public bool IsSystem { get; set; }
    public int NumberOfTanks { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public List<Parameter> Parameters { get; set; } = new List<Parameter>();
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class WaterType {
    public static string Salt => "salt";
    public static string Fresh => "fresh";
  }

  public class VolumeType {
    public static string Liters => "L";
    public static string Gallons => "G";
  }
}