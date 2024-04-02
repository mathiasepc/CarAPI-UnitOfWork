using System.Collections.ObjectModel;

namespace Endpoint.Controllers.Resources;

public class MakeResource : BaseModelResource
{
    public string Name { get; set; }
    public ICollection<KeyValuePairResource> Models { get; set; }

    /// <summary>
    /// Vi undgår nullreference
    /// </summary>
    public MakeResource()
    {
        Models = new Collection<KeyValuePairResource>();
    }
}
