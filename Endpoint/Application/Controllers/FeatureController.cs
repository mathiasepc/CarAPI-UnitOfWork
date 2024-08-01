using AutoMapper;
using Endpoint.DTO.Resources;
using Microsoft.AspNetCore.Mvc;
using Queries.Core;
using Queries.Core.Domain;

namespace Endpoint.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeatureController : ControllerBase
{
    private IUnitOfWork unitOfWork { get; set; }
    private IMapper mapper { get; set; }

    public FeatureController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<KeyValuePairResource>>> GetFeatured()
    {
        var features = await unitOfWork.FeatureRepo.GetFeatured();

        return Ok(mapper.Map<IEnumerable<Feature>, IEnumerable<KeyValuePairResource>>(features));
    }
}
