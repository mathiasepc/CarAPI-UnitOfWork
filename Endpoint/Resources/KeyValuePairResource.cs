using System.ComponentModel.DataAnnotations;

namespace Endpoint.Resources;

/// <summary>
/// Vi har sammensat alle modeler, som kun har Id og name. Før kom den nemlig med alle relationer, gør den ikke mere.
/// Det er en universel måde at navngive sådanne modeller på med: KeyValuePair.
/// </summary>
public class KeyValuePairResource : BaseModelResource
{
    [Required(ErrorMessage = "Mangler navn.")]
    public string Name { get; set; }
}
