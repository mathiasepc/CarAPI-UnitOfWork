using AutoMapper;
using Endpoint.Controllers.Resources;
using Endpoint.Utilities.Models;

namespace Endpoint.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Make, MakeResource>();
        CreateMap<Model, ModelResource>();
    }
}
