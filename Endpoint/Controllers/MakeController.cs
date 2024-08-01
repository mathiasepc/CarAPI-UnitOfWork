using AutoMapper;
using Endpoint.Resources;
using Microsoft.AspNetCore.Mvc;
using Queries.Core;
using Queries.Core.Domain;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MakeController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public MakeController(IUnitOfWork unitOfWork, IMapper mapper) 
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MakeResource>>> GetMakes()
    {
        var makes = await unitOfWork.MakeRepo.GetMake();

        return Ok(mapper.Map<IEnumerable<Make>, IEnumerable<MakeResource>>(makes));
    }
}
