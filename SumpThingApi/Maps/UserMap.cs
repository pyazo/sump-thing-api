using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SumpThingApi.Models;

namespace SumpThingApi.Maps
{
  public class UserMap
  {
    public UserMap (EntityTypeBuilder<User> e)
    {
      e.HasKey (x => x.Id);
      e.ToTable ("users");

      e.Property (x => x.Id).HasColumnName ("id");
      e.Property (x => x.FirstName).HasColumnName ("first_name");
      e.Property (x => x.LastName).HasColumnName ("last_name");
      e.Property (x => x.Auth0Token).HasColumnName ("auth0_token");
      e.Property (x => x.Email).HasColumnName ("email");
      e.Property (x => x.PhoneNumber).HasColumnName ("phone_number");
      e.Property (x => x.UpdatedAt).HasColumnName ("updated_at");
      e.Property (x => x.CreatedAt).HasColumnName ("created_at");
    }
  }
}