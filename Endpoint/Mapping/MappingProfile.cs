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
        // Domain to API Resources
        CreateMap<Make, MakeResource>();
        CreateMap<Model, ModelResource>();
        CreateMap<Features, FeaturedResource>();

        // API Resource to Domain
        CreateMap<VehicleResource, Vehicle>()
            .ForMember(v => v.Contact.Name, opt => opt.MapFrom(vr => vr.ContactResource.Name))
            .ForMember(v => v.Contact.Email, opt => opt.MapFrom(vr => vr.ContactResource.Email))
            .ForMember(v => v.Contact.Phone, opt => opt.MapFrom(vr => vr.ContactResource.Phone));
    }
}
