using System.Collections.Generic;

namespace SumpThingApi.Models {
  public class Account {
    public int Id { get; set; }
    public string ResourceType { get; set; }
    public int ResourceId { get; set; }
    public List<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
    public List<Tank> Tanks { get; set; } = new List<Tank>();
  }

  public class ResourceType {
    public static string User => "user";
    public static string Company => "company";
  }
}