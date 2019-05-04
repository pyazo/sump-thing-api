using SumpThingApi.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SumpThingApi.Maps {
  public class TankMap {
    public TankMap(EntityTypeBuilder<Tank> e) {
      e.HasKey(x => x.Id);
      e.ToTable("tanks");

      e.Property(x => x.Id).HasColumnName("id");
      e.Property(x => x.Name).HasColumnName("name");
      e.Property(x => x.WaterType).HasColumnName("water_type");
      e.Property(x => x.TankType).HasColumnName("tank_type");
      e.Property(x => x.Volume).HasColumnName("volume");
      e.Property(x => x.VolumeUnit).HasColumnName("volume_unit");
      e.Property(x => x.IsSystem).HasColumnName("is_system");
      e.Property(x => x.NumberOfTanks).HasColumnName("number_of_tanks");
      e.Property(x => x.AccountId).HasColumnName("account_id");
    }
  }
}