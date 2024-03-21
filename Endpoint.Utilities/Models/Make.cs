using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Utilities.Models;

public class Make : BaseModel
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    // Model reference 1 - M
    public ICollection<Model>? Models { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Make()
    {
        Models = new Collection<Model>();
    }
}

