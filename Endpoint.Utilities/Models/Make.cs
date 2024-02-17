using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Utilities.Models;

public class Make
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; }

    /// <summary>
    /// Vi undgår nullreference
    /// </summary>
    public Make()
    {
        Models = new Collection<Model>();
    }
}

