using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;

[Table("Features")]
public class Featured
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

    public Featured()
    {
        _id = Guid.NewGuid();
    }
}
