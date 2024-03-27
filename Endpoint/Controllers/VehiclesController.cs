using AutoMapper;
using Endpoint.Controllers.Resources;
using Endpoint.Utilities.Interface;
using Endpoint.Utilities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IRepo repo;
    public VehiclesController(IMapper mapper, IRepo repo)
    {
        this.mapper = mapper;
        this.repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
    {
        // Dataannotations griber alt undtaget ModelId.
        if (vehicleResource.ModelId == Guid.Empty) return BadRequest("Der mangler ModelId");

        // Mapper vehicleResource til Vehicle
        var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

        var result = await repo.Insert(vehicle);

        return result == true ? Ok(mapper.Map<Vehicle, SaveVehicleResource>(vehicle)) : BadRequest("Noget gik galt da vi prøvede at gemme.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] SaveVehicleResource vehicleResource)
    {
        // Dataannotations griber alt undtaget ModelId. 
        if (vehicleResource.ModelId == Guid.Empty) return BadRequest("Der mangler ModelId"); 

        var vehicleTemp = await repo.GetVehicleById(id);

        if (vehicleTemp == null) return NotFound();

        // Mapper vehicleResource til Vehicle
        var vehicle = mapper.Map(vehicleResource, vehicleTemp);

        var result = await repo.SaveAsync();

        return result == true ? Ok(mapper.Map<Vehicle, SaveVehicleResource>(vehicle)) : BadRequest("Noget gik galt da vi prøvede at gemme.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(Guid id)
    {
        var vehicle = await repo.GetVehicleById(id);        

        return vehicle == null ? NotFound("Vehicle fandtes ikke.") : Ok(await repo.DeleteVehicle(vehicle));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicle(Guid id)
    {
        var vehicle = await repo.GetVehicleById(id);

        return vehicle == null ? NotFound("Vehicle fandtes ikke.") : Ok(mapper.Map<Vehicle, VehicleResource>(vehicle));
    }
}
