using Repositories;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Models;
namespace Repositories.SeedData
{
    public class DevelopmentUsers
    {

        public static void SeedData(UserManager<AppUser> userManager)
        {
            IdentityResult result;

            var user = new AppUser
            {
               FirstName = "Admin",
               UserName = "test@gamenvyemail.com",
               LastName = "User",
               Email = "test@gamenvyemail.com",
               EmailConfirmed = true,
            };

            result = userManager.CreateAsync(user, "Passw0rd!").Result;

        }
    }
}
