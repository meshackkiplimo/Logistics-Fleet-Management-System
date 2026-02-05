using FleetService.Models;

namespace FleetService.Services;

public interface ITrackingService
{
    Task<Location> UpdateLocationAsync(Guid driverId, double latitude, double longitude, string? orderId);
    Task<Location?> GetLatestLocationAsync(Guid driverId);
    Task<List<Location>> GetLocationHistoryAsync(Guid driverId, DateTime from, DateTime to);
}
