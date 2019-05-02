using System.Collections.Generic;

namespace SumpThingApi.Models {
  public class Account {
    public int Id { get; set; }
    public string ResourceType { get; set; }
    public int ResourceId { get; set; }
    public List<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
  }
}