using System;
using System.Collections.Generic;

namespace SumpThingApi.Models {
  public class ParameterValue {
    public int Id { get; set; }
    public int Value { get; set; }
    public string Notes { get; set; }
    public int ParemeterId { get; set; }
    public Parameter Parameter { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}