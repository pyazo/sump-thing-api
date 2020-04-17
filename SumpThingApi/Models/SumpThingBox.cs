using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumpThingApi.Models
{
  public class SumpThingBox
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Nullable<int> TankId { get; set; }
    public Tank Tank { get; set; }
    public string AccessToken { get; set; }
    public string UUID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}