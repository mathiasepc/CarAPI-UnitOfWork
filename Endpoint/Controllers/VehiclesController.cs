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
    //private IMapper _mapper;
    //private IRepo _repo; 
    //public VehiclesController(IMapper mapper, IRepo repo)
    //{
    //    _mapper = mapper;
    //    _repo = repo;
    //}

    [HttpPost]
    public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
    {
        return Ok(vehicle);
    }
}
