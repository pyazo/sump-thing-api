using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumpThingApi.Models
{
  public class User
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Auth0Token { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public virtual List<UserAccount> UserAccounts { get; set; } = new List<UserAccount> ();
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}