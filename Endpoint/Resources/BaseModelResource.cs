namespace Endpoint.Resources;

public class BaseModelResource
{
    private Guid _id { get; set; }

    public Guid Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public BaseModelResource()
    {
        _id = Guid.NewGuid();
    }
}
