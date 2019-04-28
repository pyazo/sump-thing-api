using SumpThingApi.Maps;
using SumpThingApi.Models;

using Microsoft.EntityFrameworkCore;
using System;

namespace SumpThingApi.Models {
  public class ApiDbContext : DbContext {
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      new UserMap(modelBuilder.Entity<User>());
    }
  }
}