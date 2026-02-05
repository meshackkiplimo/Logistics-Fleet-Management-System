using FleetService.Data;
using FleetService.DTOs;
using FleetService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly FleetDbContext _context;

    public VehiclesController(FleetDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> GetAll()
    {
        return await _context.Vehicles.Include(v => v.Driver).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetById(Guid id)
    {
        var vehicle = await _context.Vehicles.Include(v => v.Driver).FirstOrDefaultAsync(v => v.Id == id);
        if (vehicle == null) return NotFound();
        return vehicle;
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(CreateVehicleDto dto)
    {
        var vehicle = new Vehicle
        {
            RegistrationNumber = dto.RegistrationNumber,
            Type = dto.Type,
            Status = VehicleStatus.Active
        };

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CreateVehicleDto dto)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null) return NotFound();

        vehicle.RegistrationNumber = dto.RegistrationNumber;
        vehicle.Type = dto.Type;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null) return NotFound();

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
