using Microsoft.AspNetCore.Identity;

namespace E_Commerce_API.Identity
{
    public class AppIdentitySeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> _userMnager)
        {
            if (!_userMnager.Users.Any())
            {
                AppUser user = new()
                {
                    DisplayName = "Hameed Hassan",
                    Email = "hameedhassan9542@gmail.com",
                    UserName = "hameed00",
                    Address = new Address
                    {
                        FirstName = "Hameed",
                        LastName = "Hassan",
                        Street = "Al-Azhar",
                        City = "Cairo",
                        State = "Egypt",
                        ZipCode = "16599"

                    }
                };

                await _userMnager.CreateAsync(user,"Pass0wrd12@");    
            }
        }
    }
}
