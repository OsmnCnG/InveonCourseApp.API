using InveonCourseApp.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Repository.Seeds
{
    public static class CategorySeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.EnsureCreatedAsync();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new[]
            {
                new Category
                {
                    Name = "Yazılım",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Name = "Tasarım",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Name = "Kişisel Gelişim",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Name = "Müzik",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Name = "Pazarlama",
                    CreatedDate = DateTime.Now,
                },
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }
    }
}
