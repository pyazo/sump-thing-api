using System;

namespace SumpThingApi.Models
{
  public class Registration
  {
    public int Id { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public int SumpThingBoxId { get; set; }
    public SumpThingBox SumpThingBox { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
  }
}