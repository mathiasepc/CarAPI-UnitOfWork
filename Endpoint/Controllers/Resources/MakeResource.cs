using System.Collections.ObjectModel;

namespace Endpoint.Controllers.Resources;

public class MakeResource : BaseModelResource
{
    public string Name { get; set; }
    public ICollection<ModelResource> Models { get; set; }

    /// <summary>
    /// Vi undgår nullreference
    /// </summary>
    public MakeResource()
    {
        Models = new Collection<ModelResource>();
    }
}
