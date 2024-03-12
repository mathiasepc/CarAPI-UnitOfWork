using AutoMapper;
using Endpoint.Controllers.Resources;
using Endpoint.Utilities.Models;

namespace Endpoint.Mapping;

public class MappingProfile : Profile
{
    /// <summary>
    /// Her laver jeg mapping profilerne. 
    /// </summary>
    public MappingProfile() 
    {
        CreateMap<Make, MakeResource>();
        CreateMap<Model, ModelResource>();
        CreateMap<Features, FeaturedResource>();
        CreateMap<Vehicle, VehicleResource>();
    }
}
