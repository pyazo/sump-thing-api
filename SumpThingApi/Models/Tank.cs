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
  }

  public class WaterType {
    private WaterType(string value) { Value = value; }
    public string Value { get; set; }
    public static WaterType Salt { get { return new WaterType("salt"); } }
    public static WaterType Fresh { get { return new WaterType("fresh"); } }
  }

  public class VolumeType {
    private VolumeType(string value) { Value = value; }
    public string Value { get; set; }
    public static VolumeType Liters { get { return new VolumeType("L"); } }
    public static VolumeType Gallons { get { return new VolumeType("G"); } }
  }
}