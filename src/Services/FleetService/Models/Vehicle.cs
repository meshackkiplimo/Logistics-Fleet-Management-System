namespace FleetService.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public VehicleStatus Status { get; set; }
    public Guid? DriverId { get; set; }
    public Driver? Driver { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public enum VehicleStatus
{
    Active,
    Idle,
    Maintenance,
    Inactive
}
