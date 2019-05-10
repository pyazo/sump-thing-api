using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SumpThingApi.Models;

namespace SumpThingApi.Maps
{
  public class UserAccountMap
  {
    public UserAccountMap (EntityTypeBuilder<UserAccount> e)
    {
      e.HasKey (x => x.Id);
      e.ToTable ("user_accounts");

      e.Property (x => x.Id).HasColumnName ("id");
      e.Property (x => x.UserId).HasColumnName ("user_id");
      e.Property (x => x.AccountId).HasColumnName ("account_id");
      e.Property (x => x.UpdatedAt).HasColumnName ("updated_at");
      e.Property (x => x.CreatedAt).HasColumnName ("created_at");
    }
  }
}