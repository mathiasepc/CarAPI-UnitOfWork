using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Controllers.Resources;

public class ModelResource : BaseModelResource
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    public ModelResource()
    {
    }
}
