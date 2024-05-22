using Microsoft.EntityFrameworkCore;
using Queries.Persistence.EntityConfigurations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Queries.Core.Domain;

[Table("Makes")]
public class Make : BaseModel
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    // Model reference 1 - M
    public ICollection<Model> Models { get; set; }

    /// <summary>
    /// Undgår nullreference
    /// </summary>
    public Make()
    {
        Models = new Collection<Model>();
    }
}

