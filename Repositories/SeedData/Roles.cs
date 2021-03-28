using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.SeedData
{
    public class Roles
    {
        private static readonly string[] roles = new string[] { "Administrator", "User" };
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager, GamEnvyDbContext dbContext)
        {
                if (!dbContext.UserRoles.Any())
                {
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }
                }
        }
    }



}
