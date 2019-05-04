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
    private ResourceType(string value) { Value = value; }
    public string Value { get; set; }
    public static ResourceType User { get { return new ResourceType("user"); } }
    public static ResourceType Company { get { return new ResourceType("company"); } }
  }
}