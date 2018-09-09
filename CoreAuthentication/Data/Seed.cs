using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAuthentication.Data
{
    public static class Seed
    {
        public static async Task CreateAspNetRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //adding customs roles
            RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                bool roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            // creating a super user who could maintain the web app
            IdentityUser poweruser = new IdentityUser
            {
                UserName = Configuration["UserSettings:UserEmail"],
                Email = Configuration["UserSettings:UserEmail"],
            };
            string userPassword = Configuration["UserSettings:UserPassword"];
            IdentityUser user = await UserManager.FindByEmailAsync(Configuration["UserSettings:UserEmail"]);
            if (user == null)
            {
                IdentityResult createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
        public static async Task CreateAspNetRoleClaims(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminRoleB = await roleManager.FindByNameAsync("AdminB");
            ClaimsIdentity Subject = new ClaimsIdentity();

            if (adminRoleB == null)
            {
                adminRoleB = new IdentityRole("AdminB");
                await roleManager.CreateAsync(adminRoleB);

                await roleManager.AddClaimAsync(adminRoleB, new Claim("Type", "value", "valueType", "issuer", "originalIssuer", Subject));

            }
        }
    }
}
