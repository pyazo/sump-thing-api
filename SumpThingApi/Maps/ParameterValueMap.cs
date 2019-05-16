using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SumpThingApi.Models;

namespace SumpThingApi.Maps
{
  public class ParameterValueMap
  {
    public ParameterValueMap (EntityTypeBuilder<ParameterValue> e)
    {
      e.HasKey (x => x.Id);
      e.ToTable ("parameter_values");

      e.Property (x => x.Id).HasColumnName ("id");
      e.Property (x => x.Value).HasColumnName ("value");
      e.Property (x => x.Notes).HasColumnName ("notes");
      e.Property (x => x.ParameterId).HasColumnName ("parameter_id");
      e.Property (x => x.UpdatedAt).HasColumnName ("updated_at");
      e.Property (x => x.CreatedAt).HasColumnName ("created_at");
    }
  }
}