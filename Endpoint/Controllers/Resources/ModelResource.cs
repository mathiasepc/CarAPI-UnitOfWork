using System.Collections.ObjectModel;

namespace Endpoint.Controllers.Resources;

public class ModelResource
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ModelResource()
    {
    }
}
