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
        if (vehicleResource == null) return BadRequest();

        try
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            var result = await repo.Insert(vehicle);

            return result == true ? Ok(mapper.Map<Vehicle, VehicleResource>(vehicle)) : BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
