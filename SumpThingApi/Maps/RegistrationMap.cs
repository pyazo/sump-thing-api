using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SumpThingApi.Models;

namespace SumpThingApi.Maps
{
  public class RegistrationMap
  {
    public RegistrationMap (EntityTypeBuilder<Registration> e)
    {
      e.HasKey (x => x.Id);
      e.ToTable ("registrations");

      e.Property (x => x.Id).HasColumnName ("id");
      e.Property (x => x.AccountId).HasColumnName ("account_id");
      e.Property (x => x.SumpThingBoxId).HasColumnName ("sump_thing_box_id");
      e.Property (x => x.CreatedAt).HasColumnName ("created_at");
      e.Property (x => x.UpdatedAt).HasColumnName ("updated_at");
    }
  }
}