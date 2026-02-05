using FleetService.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetService.Data;

public class FleetDbContext : DbContext
{
    public FleetDbContext(DbContextOptions<FleetDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Driver)
            .WithOne(d => d.Vehicle)
            .HasForeignKey<Driver>(d => d.VehicleId);

        modelBuilder.Entity<Location>()
            .HasIndex(l => l.DriverId);
    }
}
