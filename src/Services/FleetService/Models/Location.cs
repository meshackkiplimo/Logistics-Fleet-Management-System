namespace FleetService.Models;

public class Location
{
    public Guid Id { get; set; }
    public Guid DriverId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string? OrderId { get; set; }
}
