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

            var admin = new AppUser
            {
               FirstName = "Admin",
               UserName = "admin@gamenvyemail.com",
               LastName = "User",
               Email = "admin@gamenvyemail.com",
               EmailConfirmed = true,
            };

            result = userManager.CreateAsync(admin, "Passw0rd!").Result;
            if(result.Succeeded)
            {
                var result1 = userManager.AddToRoleAsync(admin, "Administrator").Result;
            }

            var user = new AppUser
            {
                FirstName = "Normal",
                UserName = "user@gamenvyemail.com",
                LastName = "User",
                Email = "user@gamenvyemail.com",
                EmailConfirmed = true,
            };

            result = userManager.CreateAsync(user, "Passw0rd!").Result;
            if (result.Succeeded)
            {
                var result1 = userManager.AddToRoleAsync(user, "User").Result;
            }

        }
    }
}
