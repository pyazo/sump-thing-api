using System;
using Microsoft.EntityFrameworkCore;
using SumpThingApi.Maps;
using SumpThingApi.Models;

namespace SumpThingApi.Models
{
  public class ApiDbContext : DbContext
  {
    public ApiDbContext (DbContextOptions<ApiDbContext> options) : base (options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      base.OnModelCreating (modelBuilder);

      new UserMap (modelBuilder.Entity<User> ());
      new AccountMap (modelBuilder.Entity<Account> ());
      new UserAccountMap (modelBuilder.Entity<UserAccount> ());
      new TankMap (modelBuilder.Entity<Tank> ());
      new ParameterMap (modelBuilder.Entity<Parameter> ());
      new ParameterValueMap (modelBuilder.Entity<ParameterValue> ());

      modelBuilder.Entity<UserAccount> ()
        .HasKey (ua => new { ua.AccountId, ua.UserId });

      modelBuilder.Entity<UserAccount> ()
        .HasOne (ua => ua.User)
        .WithMany (u => u.UserAccounts)
        .HasForeignKey (ua => ua.UserId);

      modelBuilder.Entity<UserAccount> ()
        .HasOne (ua => ua.Account)
        .WithMany (a => a.UserAccounts)
        .HasForeignKey (ua => ua.AccountId);

      modelBuilder.Entity<Tank> ()
        .HasKey (t => new { t.AccountId });

      modelBuilder.Entity<Tank> ()
        .HasOne (t => t.Account)
        .WithMany (a => a.Tanks)
        .HasForeignKey (t => t.AccountId);
    }
  }
}