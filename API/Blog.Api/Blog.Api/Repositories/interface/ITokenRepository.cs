using Microsoft.AspNetCore.Identity;

namespace Blog.Api.Repositories .Interface
{
    public interface ITokenRepository
{
        string CreateJwtToken(IdentityUser user, List<string> roles);

    }
}
