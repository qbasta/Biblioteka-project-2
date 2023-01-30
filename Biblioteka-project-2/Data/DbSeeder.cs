using Biblioteka_project_2.Constants;
using Biblioteka_project_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Biblioteka_project_2.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<User>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // creating admin

            var user1 = new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "First Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user2 = new User
            {
                UserName = "moderator@gmail.com",
                Email = "moderator@gmail.com",
                Name = "First Moderator",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var user1InDb = await userManager.FindByEmailAsync(user1.Email);
            var user2InDb = await userManager.FindByEmailAsync(user2.Email);
            if (user1InDb == null)
            {
                await userManager.CreateAsync(user1, "Admin@123");
                await userManager.AddToRoleAsync(user1, Roles.Admin.ToString());
            }
            if (user2InDb == null)
            {
                await userManager.CreateAsync(user2, "Moderator@123");
                await userManager.AddToRoleAsync(user2, Roles.Moderator.ToString());
            }
        }
    }
}

