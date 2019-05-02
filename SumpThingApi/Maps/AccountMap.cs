using SumpThingApi.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SumpThingApi.Maps {
  public class AccountMap {
    public AccountMap(EntityTypeBuilder<Account> e) {
      e.HasKey(x => x.Id);
      e.ToTable("accounts");

      e.Property(x => x.Id).HasColumnName("id");
      e.Property(x => x.ResourceType).HasColumnName("resource_type");
      e.Property(x => x.ResourceId).HasColumnName("resource_id");
    }
  }
}