using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SumpThingApi.Models
{
  [JsonObject (NamingStrategyType = typeof (SnakeCaseNamingStrategy))]
  public class Account
  {
    public int Id { get; set; }
    public string ResourceType { get; set; }
    public int ResourceId { get; set; }
    public List<UserAccount> UserAccounts { get; set; } = new List<UserAccount> ();
    public List<Tank> Tanks { get; set; } = new List<Tank> ();
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class ResourceType
  {
    public static string User => "user";
    public static string Company => "company";
  }
}