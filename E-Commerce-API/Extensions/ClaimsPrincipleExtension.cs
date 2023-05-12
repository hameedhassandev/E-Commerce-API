using System.Security.Claims;

namespace E_Commerce_API.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static string RetrieveEmailFromPrinciple(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}
