using AutoMapper;
using Endpoint.Controllers.Resources;
using Endpoint.Utilities.Interface;
using Endpoint.Utilities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeatureController : ControllerBase
{
    private IRepo _repository { get; set; }
    private IMapper _mapper { get; set; }

    public FeatureController(IMapper mapper, IRepo repo)
    {
        _mapper = mapper;
        _repository = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeaturedResource>>> GetFeatured()
    {
        var features = await _repository.GetFeatured();

        return Ok(_mapper.Map<IEnumerable<Feature>,IEnumerable<FeaturedResource>>(features));
    }
}
