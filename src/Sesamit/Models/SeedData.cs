using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Sesamit.Models
{
    public class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser
            {
                UserName = "it@sesamit.se",
                Email = "it@sesamit.se"
            };

            var result = await roleManager.RoleExistsAsync("Admin");
            if (result) return;

            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("StandardUser"));

            var userResult = await userManager.CreateAsync(user, "sesam123");
            if (userResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                throw new Exception(userResult.ToString());
            }

        }
    }
}
