using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SumpThingApi.Models;

namespace SumpThingApi.Maps
{
  public class ParameterMap
  {
    public ParameterMap (EntityTypeBuilder<Parameter> e)
    {
      e.HasKey (x => x.Id);
      e.ToTable ("parameters");

      e.Property (x => x.Id).HasColumnName ("id");
      e.Property (x => x.Name).HasColumnName ("name");
      e.Property (x => x.Unit).HasColumnName ("unit");
      e.Property (x => x.Max).HasColumnName ("max");
      e.Property (x => x.Min).HasColumnName ("min");
      e.Property (x => x.ChangeWarningInterval).HasColumnName ("change_warning_interval");
      e.Property (x => x.TankId).HasColumnName ("tank_id");
      e.Property (x => x.SumpThingBoxId).HasColumnName ("sump_thing_box_id");
      e.Property (x => x.UpdatedAt).HasColumnName ("updated_at");
      e.Property (x => x.CreatedAt).HasColumnName ("created_at");
    }
  }
}