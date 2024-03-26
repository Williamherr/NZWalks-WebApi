using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repository.Auth
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);

    }
}
