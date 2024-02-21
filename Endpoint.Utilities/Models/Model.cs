using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Endpoint.Utilities.Models;

[Table("Models")]
public class Model
{
    private Guid _id;

    public Guid Id
    {
        get { return _id; }
        set { _id = value; }
    }

    [Required]
    [StringLength(255)]
    public string name { get; set; }
    public Make Make { get; set; }
    public Guid MakeId { get; set; }

    public Model()
    {
        _id = Guid.NewGuid();
    }
}