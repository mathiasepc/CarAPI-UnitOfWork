using AutoMapper;
using Endpoint.Controllers.Resources;
using Endpoint.Utilities.Models;
using Endpoint.Utilities.Models.LinkTables;

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
        CreateMap<Feature, FeaturedResource>();
        CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.ContactResource, opt => opt.MapFrom(v => v.Contact))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

        // Complex type
        CreateMap<ContactResource, Contact>();
        CreateMap<Contact, ContactResource>();

        // API Resource to Domain
        CreateMap<VehicleResource, Vehicle>()
            .ForMember(v => v.Contact, opt => opt.MapFrom(vr => vr.ContactResource))
            .ForMember(v => v.ModelId, opt => opt.MapFrom(vr => vr.ModelId))
            .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })));
    }
}
