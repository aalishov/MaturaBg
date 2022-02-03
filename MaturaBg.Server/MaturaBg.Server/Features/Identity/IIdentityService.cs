
namespace MaturaBg.Features.Identity
{
    public interface IIdentityService
    {
        string GenreateJwtTokken(string userID, string username, string secret);

    }
}
