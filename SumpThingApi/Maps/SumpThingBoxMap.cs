using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SumpThingApi.Models;

namespace SumpThingApi.Maps
{
  public class SumpThingBoxMap
  {
    public SumpThingBoxMap (EntityTypeBuilder<SumpThingBox> e)
    {
      e.HasKey (x => x.Id);
      e.ToTable ("sump_thing_boxes");

      e.Property (x => x.Id).HasColumnName ("id");
      e.Property (x => x.TankId).HasColumnName ("tank_id");
      e.Property (x => x.AccessToken).HasColumnName ("access_token");
      e.Property (x => x.UUID).HasColumnName ("uuid");
      e.Property (x => x.CreatedAt).HasColumnName ("created_at");
      e.Property (x => x.UpdatedAt).HasColumnName ("updated_at");
    }
  }
}