using AutoMapper;
using Endpoint.Controllers.Resources;
using Queries.Core.Domain;
using Queries.Core.Domain.LinkTables;

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
        CreateMap<Make, KeyValuePairResource>();
        CreateMap<Model, KeyValuePairResource>();
        CreateMap<Feature, KeyValuePairResource>();
        CreateMap<Vehicle, SaveVehicleResource>()
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => v.Contact))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.VehicleFeatures.Select(vf => vf.FeatureId)));
        CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => v.Contact))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.VehicleFeatures.Select(vf => new KeyValuePairResource { Id = vf.FeatureId, Name = vf.Feature.Name })));

        // Complex type
        CreateMap<ContactResource, Contact>();
        CreateMap<Contact, ContactResource>();

        // API Resource to Domain
        CreateMap<SaveVehicleResource, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.Contact, opt => opt.MapFrom(vr => vr.Contact))
            .ForMember(v => v.ModelId, opt => opt.MapFrom(vr => vr.ModelId))
            .ForMember(v => v.VehicleFeatures, opt => opt.Ignore())
            .AfterMap((vr, v) =>
            {
                // Da vi iterer over v.Features/vr.features collection, vi kan ikke modify i runtime.
                // Det vil give en throw en runtime exception.

                // Gemmer unselected features i removedFeatures. For så at slette.
                var removedFeatures = v.VehicleFeatures.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();

                // Fjerner unselected features fra vehicle.
                foreach (var feature in removedFeatures)
                    v.VehicleFeatures.Remove(feature);

                // Tilføjer new Features til addFeatures
                var addFeatures = vr.Features.Where(id => !v.VehicleFeatures.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id }).ToList();

                // Tilføjer dem til vehicle.
                foreach (var feature in addFeatures)
                    v.VehicleFeatures.Add(feature);
            });
    }
}
