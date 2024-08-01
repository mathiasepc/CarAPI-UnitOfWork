﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Queries.Core;
using Queries.Core.Domain;
using Endpoint.Resources;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public VehiclesController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<VehicleResource>> GetVehicles([FromQuery] VehicleQueryResource filterResource)
    {
        var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);

        return mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(await unitOfWork.VehicleRepo.GetVehicles(filter));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicle(Guid id)
    {
        return id != Guid.Empty 
            ? Ok(mapper.Map<Vehicle, VehicleResource>(await unitOfWork.VehicleRepo.GetVehicleById(id, includeRelated: true)))
            : BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
    { 
        // Mapper SaveVehicleResource til Vehicle
        var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

        unitOfWork.VehicleRepo.AddVehicle(vehicle);

        var result = unitOfWork.Complete();

        return result > 0
            ? Ok(mapper.Map<Vehicle, VehicleResource>(await unitOfWork.VehicleRepo.GetVehicleById(vehicle.Id)))
            : BadRequest("Noget gik galt da den prøvede at gemme.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] SaveVehicleResource vehicleResource)
    {
        var vehicle = await unitOfWork.VehicleRepo.GetVehicleById(id, true);

        if (vehicle == null) return NotFound($"Bilen findes ikke: {id}");

        // Merger vehicleResource og vehicle værdierne sammen, i Vehicle
        mapper.Map(vehicleResource, vehicle);

        var result = unitOfWork.Complete();

        return result > 0
            ? Ok(mapper.Map<Vehicle, VehicleResource>(await unitOfWork.VehicleRepo.GetVehicleById(vehicle.Id)))
            : BadRequest("Noget gik galt da den prøvede at gemme.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(Guid id)
    {
        // includeRelated: false = vi henter ikke relationer.
        var vehicle = await unitOfWork.VehicleRepo.GetVehicleById(id, includeRelated: false);

        if (vehicle == null) return NotFound($"Bilen findes ikke: {id}");

        unitOfWork.VehicleRepo.RemoveVehicle(vehicle);

        var result = unitOfWork.Complete();

        return result > 0
            ? Ok(mapper.Map<Vehicle, VehicleResource>(vehicle))
            : BadRequest("Noget gik galt da den prøvede at gemme");
    }
}
