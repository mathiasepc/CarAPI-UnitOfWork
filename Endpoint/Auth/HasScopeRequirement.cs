using Microsoft.AspNetCore.Authorization;

namespace Endpoint.Auth;

public class HasScopeRequirement : IAuthorizationRequirement
{
    public string Issuer { get; }
    public string Scope { get; }

    public HasScopeRequirement(string scope, string issuer)
    {
        // ?? = Null-coalescing
        // Hvis null returner throw. Hvis ikke nulle returner Scope eller Issuer.
        Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
    }
}