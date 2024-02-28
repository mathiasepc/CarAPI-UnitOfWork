using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Utilities.Models;

public class Make
{
    private Guid _id;

    public Guid Id
    {
        get { return _id; }
        set { _id = value; }
    }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; }

    /// <summary>
    /// Vi undgår nullreference
    /// </summary>
    public Make()
    {
        _id = Guid.NewGuid();
        Models = new Collection<Model>();
    }
}

