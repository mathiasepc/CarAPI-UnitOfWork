
namespace Endpoint.Utilities.Models;

// BaseModel Har alle fælles properties.
public class BaseModel
{
    private Guid? _id { get; set; }
    public Guid Id
    {
        get { return (Guid)_id; }
        set { _id = value; }
    }
    public BaseModel() 
    {
        _id = Guid.NewGuid();
    }
}
