using Endpoint.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Application.Resources;

public class BaseModelResource
{
    [Required]
    private Guid _id { get; set; }

    [Required]
    public Guid Id
    {
        get { return (Guid)_id; }
        set { _id = value; }
    }
    public BaseModelResource()
    {
        _id = Guid.NewGuid();
    }
}
