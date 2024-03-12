using AutoMapper;
using Endpoint.Controllers.Resources;
using Endpoint.Utilities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IMapper _mapper;
    public VehiclesController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
    {
        var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);

        return Ok(vehicle);
    }
}
