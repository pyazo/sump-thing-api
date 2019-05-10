using System;
using System.Collections.Generic;

namespace SumpThingApi.Models {
  public class Parameter {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public int Max { get; set; }
    public int Min { get; set; }
    public int ChangeWarningInterval { get; set; } // In minutes
    public int TankId { get; set; }
    public Tank Tank { get; set; }
    public int SumpThingBoxId { get; set; }
    public List<ParameterValue> Values { get; set; } =  new List<ParameterValue>();
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}