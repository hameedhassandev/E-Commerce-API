using E_Commerce_API.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Commerce_API.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<AppUser> FindUserByClaimsWithAddress(this UserManager<AppUser> _userManager,
            ClaimsPrincipal _user)
        {
            var email = _user.FindFirstValue(ClaimTypes.Email);
            return await _userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);   
        }

        public static async Task<AppUser> FindEmailFromClaims(this UserManager<AppUser> _userManager,
           ClaimsPrincipal _user)
        {
            return await _userManager.Users.SingleOrDefaultAsync(x => x.Email == _user.FindFirstValue(ClaimTypes.Email));
        }
    }
}
