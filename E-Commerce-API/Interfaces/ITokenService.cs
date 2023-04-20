using E_Commerce_API.Identity;

namespace E_Commerce_API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
