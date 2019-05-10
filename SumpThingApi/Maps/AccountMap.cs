using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SumpThingApi.Models;

namespace SumpThingApi.Maps
{
  public class AccountMap
  {
    public AccountMap (EntityTypeBuilder<Account> e)
    {
      e.HasKey (x => x.Id);
      e.ToTable ("accounts");

      e.Property (x => x.Id).HasColumnName ("id");
      e.Property (x => x.ResourceType).HasColumnName ("resource_type");
      e.Property (x => x.ResourceId).HasColumnName ("resource_id");
      e.Property (x => x.UpdatedAt).HasColumnName ("updated_at");
      e.Property (x => x.CreatedAt).HasColumnName ("created_at");
    }
  }
}