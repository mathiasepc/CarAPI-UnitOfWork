using AutoMapper;
using Endpoint.Controllers.Resources;
using Endpoint.Utilities.Interface;
using Endpoint.Utilities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MakeController : ControllerBase
{
    private readonly IRepo _repository;
    private readonly IMapper _mapper;
    public MakeController(IRepo repo, IMapper mapper) 
    {
        _mapper = mapper;
        _repository = repo;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MakeResource>>> GetMakes()
    {
        var makes = await _repository.GetMake();

        return Ok(_mapper.Map<IEnumerable<Make>, IEnumerable<MakeResource>>(makes));
    }
}
