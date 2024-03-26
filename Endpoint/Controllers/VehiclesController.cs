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
    public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
    {
        // Dataannotations griber alt undtaget ModelId.
        if (vehicleResource.ModelId == Guid.Empty) return BadRequest("Der mangler ModelId");

        // Mapper vehicleResource til Vehicle
        var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);

        var result = await repo.Insert(vehicle);

        return result == true ? Ok(mapper.Map<Vehicle, VehicleResource>(vehicle)) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] VehicleResource vehicleResource)
    {
        // Dataannotations griber alt undtaget ModelId. 
        if (vehicleResource.ModelId == Guid.Empty) return BadRequest("Der mangler ModelId"); 

        var vehicleTemp = await repo.GetById(id);

        // Mapper vehicleResource til Vehicle
        var vehicle = mapper.Map(vehicleResource, vehicleTemp);

        var result = await repo.UpdateAsync();

        return result == true ? Ok(mapper.Map<Vehicle, VehicleResource>(vehicle)) : BadRequest();
    }
}
