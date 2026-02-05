namespace Shared.Models;

public class LocationUpdate
{
    public string DriverId { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime Timestamp { get; set; }
    public string? OrderId { get; set; }
}
