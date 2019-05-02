using SumpThingApi.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SumpThingApi.Maps {
  public class UserAccountMap {
    public UserAccountMap(EntityTypeBuilder<UserAccount> e) {
      e.HasKey(x => x.Id);
      e.ToTable("user_accounts");

      e.Property(x => x.Id).HasColumnName("id");
      e.Property(x => x.UserId).HasColumnName("user_id");
      e.Property(x => x.AccountId).HasColumnName("account_id");
    }
  }
}