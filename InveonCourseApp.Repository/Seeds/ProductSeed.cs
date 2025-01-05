using InveonCourseApp.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Repository.Seeds
{
    public static class ProductSeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            //context.Database.EnsureCreatedAsync();

            if (context.Products.Any())
            {
                return;
            }

            var products = new[]
            {
                new Product
                {
                    Name = "Net 8 API/WEB | NLayer/Clean Architecture | Best Practice",
                    Instructor = "Fatih Çakıroğlu",
                    Price = 129.99M,
                    ImageUrl = "https://media.istockphoto.com/id/2057738345/tr/foto%C4%9Fraf/congratulations-colleague.jpg?s=2048x2048&w=is&k=20&c=MOo8qR0AcctRBvTaanWKPkpEBTTK3Pg3OSJ6ByTsLto=",
                    Duration = "24",
                    Description = "Net 8 ~ N Layer Architecture ~ Clean Architecture ~ Onion Architecture ~ Hexagonal architecture",
                    Lesson = 25,
                    Trainee = 1500,
                    CategoryId = 1,
                    InstructorUserId = 1
                },
                new Product
                {
                    Name = ".Net ile Microservices",
                    Instructor = "Fatih Çakıroğlu",
                    Price = 129.99M,
                    ImageUrl = "https://media.istockphoto.com/id/2116544916/tr/foto%C4%9Fraf/happy-business-leader-talking-to-group-of-his-colleagues-on-a-seminar-in-board-room.jpg?s=2048x2048&w=is&k=20&c=8u-6MF2UbpQrItIN6a-7g1BnzktUfCWEvM1aIhBduiQ=",
                    Duration = "45,5",
                    Description = ".Net 5.0 (upgrade .Net 7) ile microservice mimari yapısının nasıl geliştirilebileceğini öğreneceksiniz",
                    Lesson = 30,
                    Trainee = 1200,
                    CategoryId = 1,
                    InstructorUserId = 1
                },
                new Product
                {
                    Name = "Elasticsearch | Net Core",
                    Instructor = "Fatih Çakıroğlu",
                    Price = 129.99M,
                    ImageUrl = "https://media.istockphoto.com/id/2155607611/tr/foto%C4%9Fraf/mature-couple-working-on-clay-sculpture-in-ceramics-studio.jpg?s=2048x2048&w=is&k=20&c=UQODhwkk_KMs46FOlC1qYFltcXaL1rCdMBTbRUkO5O0=",
                    Duration = "10",
                    Description = "Elasticsearch'ü tüm yönleriyle öğreneceksiniz.",
                    Lesson = 18,
                    Trainee = 2000,
                    CategoryId = 1,
                    InstructorUserId = 1
                },
                new Product
                {
                    Name = "Full Stack Web Geliştirme: HTML'den .NET Core'a",
                    Instructor = "Ahmet Kaya",
                    Price = 129.99M,
                    ImageUrl = "https://media.istockphoto.com/id/1492408790/tr/foto%C4%9Fraf/learning-objectives-a-group-of-students-studying-education-brainstorming.jpg?s=2048x2048&w=is&k=20&c=z6WH6wqoIZPwy_-UEPrpgJZG2uCdO1oZqIhilj4FshA=",
                    Duration = "15,5",
                    Description = "HTML'den ASP.NET Core'a, Web Dünyasının Sırlarını Keşfedin",
                    Lesson = 99,
                    Trainee = 59,
                    CategoryId = 1,
                    InstructorUserId = 2
                },
                new Product
                {
                    Name = "Yeni Başlayanlar İçin Elektro Gitar",
                    Instructor = "Test",
                    Price = 79.99M,
                    ImageUrl = "https://media.istockphoto.com/id/1446806057/tr/foto%C4%9Fraf/young-happy-woman-student-using-laptop-watching-webinar-writing-at-home.jpg?s=2048x2048&w=is&k=20&c=krO4GzP5tPyD2u74XSW31t-MUNTR384dizWMYGtsia8=",
                    Duration = "20",
                    Description = "Sıfırdan elektro gitar çalmayı öğrenin.",
                    Lesson = 40,
                    Trainee = 13544,
                    CategoryId = 4,
                    InstructorUserId = 2
                },
                new Product
                {
                    Name = "Full-Stack Development",
                    Instructor = "Ahmet Kaya",
                    Price = 79.99M,
                    ImageUrl = "https://media.istockphoto.com/id/1448479624/tr/foto%C4%9Fraf/talking-and-working-on-video-calling.jpg?s=2048x2048&w=is&k=20&c=h44ePy8IS8IEXH5R5r2V0nZTwJMT5i9kZ9joRoiUu_Q=",
                    Duration = "20",
                    Description = "Become a full-stack developer with this comprehensive course.",
                    Lesson = 29,
                    Trainee = 1000,
                    CategoryId = 1,
                    InstructorUserId = 2
                },
                new Product
                {
                    Name = "C# Sıfırdan İleri Seviyeye",
                    Instructor = "Ahmet Kaya",
                    Price = 79.99M,
                    ImageUrl = "https://media.istockphoto.com/id/1448479624/tr/foto%C4%9Fraf/talking-and-working-on-video-calling.jpg?s=2048x2048&w=is&k=20&c=h44ePy8IS8IEXH5R5r2V0nZTwJMT5i9kZ9joRoiUu_Q=",
                    Duration = "17,5",
                    Description = "C#'ı Tüm Detayları ile Öğrenmek ve Kendinizi Geliştirmek için En İyi Adres",
                    Lesson = 59,
                    Trainee = 171,
                    CategoryId = 1,
                    InstructorUserId = 2
                },
                new Product
                {
                    Name = "JavaScript ve React ile Web Dinamiklerini Öğrenin",
                    Instructor = "Ahmet Kaya",
                    Price = 129.99M,
                    ImageUrl = "https://media.istockphoto.com/id/1468849620/tr/foto%C4%9Fraf/male-and-female-engineer-working-with-vr-glasses-control-ai-robot-arm-system-in-workshop.jpg?s=2048x2048&w=is&k=20&c=lBqmEK5kg21XJmKFb-aw4t1Hcikmiv5-4xSLCMw2a8c=",
                    Duration = "9",
                    Description = "Modern JavaScript ve React ile Dinamik Web Uygulamaları Geliştirin",
                    Lesson = 59,
                    Trainee = 17,
                    CategoryId = 1,
                    InstructorUserId = 2
                }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}
