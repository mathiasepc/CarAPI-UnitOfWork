using Endpoint.Utilities.Interface;
using Endpoint.Utilities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MakeController : ControllerBase
{
    private readonly IRepo _repository;
    public MakeController(IRepo repo) 
    {
        _repository = repo;
    }
    [HttpGet("makes")]
    public async Task<IEnumerable<Make>> GetMakes()
    {
        return await _repository.GetMake();
    }
}
