using System;

namespace SumpThingApi.Models
{
  public class SumpThingBox
  {
    public int Id { get; set; }
    public int TankId { get; set; }
    public Tank Tank { get; set; }
    public string AccessToken { get; set; }
    public string UUID { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
  }
}