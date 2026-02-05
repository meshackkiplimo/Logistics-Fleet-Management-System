using FleetService.Data;
using FleetService.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetService.Services;

public class TrackingService : ITrackingService
{
    private readonly FleetDbContext _context;

    public TrackingService(FleetDbContext context)
    {
        _context = context;
    }

    public async Task<Location> UpdateLocationAsync(Guid driverId, double latitude, double longitude, string? orderId)
    {
        var location = new Location
        {
            DriverId = driverId,
            Latitude = latitude,
            Longitude = longitude,
            OrderId = orderId,
            Timestamp = DateTime.UtcNow
        };

        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return location;
    }

    public async Task<Location?> GetLatestLocationAsync(Guid driverId)
    {
        return await _context.Locations
            .Where(l => l.DriverId == driverId)
            .OrderByDescending(l => l.Timestamp)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Location>> GetLocationHistoryAsync(Guid driverId, DateTime from, DateTime to)
    {
        return await _context.Locations
            .Where(l => l.DriverId == driverId && l.Timestamp >= from && l.Timestamp <= to)
            .OrderBy(l => l.Timestamp)
            .ToListAsync();
    }
}
