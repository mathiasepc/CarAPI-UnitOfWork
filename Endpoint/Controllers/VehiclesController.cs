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
    private readonly IUnitOfWork unitOfWork;
    public VehiclesController(IMapper mapper, IRepo repo, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.repo = repo;
        this.unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicle(Guid id)
    {
        return id != Guid.Empty ? Ok(mapper.Map<Vehicle, VehicleResource>(await repo.GetVehicleById(id))) :
            NotFound($"Bilen findes ikke: {id}");
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
    {
        // Dataannotations griber alt undtaget ModelId.
        if (vehicleResource.ModelId == Guid.Empty) return BadRequest("Der mangler ModelId");

        // Mapper SaveVehicleResource til Vehicle
        var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

        repo.InsertVehicle(vehicle);

        var result = await unitOfWork.CompleteAsync();

        return result ? Ok(mapper.Map<Vehicle, VehicleResource>(await repo.GetVehicleById(vehicle.Id))) : 
            BadRequest("Noget gik galt da vi prøvede at gemme.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] SaveVehicleResource vehicleResource)
    {
        // Dataannotations griber alt undtaget ModelId. 
        if (vehicleResource.ModelId == Guid.Empty) return BadRequest("Der mangler ModelId"); 

        var vehicle = await repo.GetVehicleById(id);

        if (vehicle == null) return NotFound();

        // Merger vehicleResource og vehicle værdierne sammen, i Vehicle
        mapper.Map(vehicleResource, vehicle);

        var result = await unitOfWork.CompleteAsync();

        return result ? Ok(mapper.Map<Vehicle, VehicleResource>(await repo.GetVehicleById(vehicle.Id))) : 
            BadRequest("Noget gik galt da vi prøvede at gemme.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(Guid id)
    {
        // includeRelated: false = vi henter ikke relationer.
        var vehicle = await repo.GetVehicleById(id, includeRelated: false);

        if (vehicle == null)
            return NotFound($"Bilen findes ikke: {id}");
        
        repo.RemoveVehicle(vehicle);

        var result = await unitOfWork.CompleteAsync();

        return result ? Ok(mapper.Map<Vehicle, VehicleResource>(vehicle)) : 
            BadRequest("Noget gik galt da vi prøvede at gemme");
    }
}
