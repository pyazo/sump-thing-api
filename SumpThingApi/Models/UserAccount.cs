using System;

namespace SumpThingApi.Models {
  public class UserAccount {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public User User { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}