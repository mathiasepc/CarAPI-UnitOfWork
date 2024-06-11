using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Application.Resources;

public class MakeResource : BaseModelResource
{
    [Required(ErrorMessage = "Mangler navn for make.")]
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
