using InveonCourseApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InveonCourseApp.Repository.Seeds
{
    public static class UserSeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.EnsureCreatedAsync();

            const string instructorRole = "Instructor";
            if (!await roleManager.RoleExistsAsync(instructorRole))
            {
                await roleManager.CreateAsync(new AppRole { Name = instructorRole });
            }

            const string instructorEmail1 = "instructor1@inveon.com";
            const string instructorPassword1 = "InveonInstructor1!";
            if (await userManager.FindByEmailAsync(instructorEmail1) == null)
            {
                var instructorUser1 = new AppUser
                {
                    UserName = instructorEmail1,
                    Email = instructorEmail1,
                };

                var result = await userManager.CreateAsync(instructorUser1, instructorPassword1);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(instructorUser1, instructorRole);
                }
            }

            const string instructorEmail2 = "instructor2@inveon.com";
            const string instructorPassword2 = "InveonInstructor2!";
            if (await userManager.FindByEmailAsync(instructorEmail2) == null)
            {
                var instructorUser2 = new AppUser
                {
                    UserName = instructorEmail2,
                    Email = instructorEmail2,
                };

                var result = await userManager.CreateAsync(instructorUser2, instructorPassword2);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(instructorUser2, instructorRole);
                }
            }

            const string regularUserEmail = "user@inveon.com";
            const string regularUserPassword = "InveonUser1!";
            if (await userManager.FindByEmailAsync(regularUserEmail) == null)
            {
                var regularUser = new AppUser
                {
                    UserName = regularUserEmail,
                    Email = regularUserEmail,
                };

                await userManager.CreateAsync(regularUser, regularUserPassword);
            }
        }
    }
}
