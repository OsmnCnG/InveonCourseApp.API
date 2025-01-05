using InveonCourseApp.Core.Models;
using InveonCourseApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Service.Services
{
    public class UserCourseService
    {
        private readonly ApplicationDbContext _appDbContext;
        public UserCourseService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Product>> GetUserCoursesAsync(int userId)
        {
            return await _appDbContext.UserCourses
                    .Where(up => up.AppUserId == userId)
                    .Select(up => up.Product)
                    .ToListAsync();
        }

        public async Task<bool> AddCourseToUserAsync(int userId, int productId)
        {
            var userExists = await _appDbContext.Users.AnyAsync(u => u.Id == userId);
            var productExists = await _appDbContext.Products.AnyAsync(p => p.Id == productId);
            if (!userExists || !productExists)
                return false;

            var alreadyExists = await _appDbContext.UserCourses.AnyAsync(up => up.AppUserId == userId && up.ProductId == productId);
            if (alreadyExists)
                return true;

            var userProduct = new UserCourse
            {
                AppUserId = userId,
                ProductId = productId,
                PurchaseDate = DateTime.Now
            };

            _appDbContext.UserCourses.Add(userProduct);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCoursesToUserAsync(int userId, List<int> productIds)
        {
            var userExists = await _appDbContext.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                return false;

            var validProductIds = await _appDbContext.Products
                .Where(p => productIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToListAsync();

            if (!validProductIds.Any())
                return false;

            var existingProductIds = await _appDbContext.UserCourses
                .Where(up => up.AppUserId == userId && validProductIds.Contains(up.ProductId))
                .Select(up => up.ProductId)
                .ToListAsync();

            var newProductIds = validProductIds.Except(existingProductIds).ToList();

            if (!newProductIds.Any())
                return false;

            var userCourses = newProductIds.Select(productId => new UserCourse
            {
                AppUserId = userId,
                ProductId = productId,
                PurchaseDate = DateTime.Now
            });

            await _appDbContext.UserCourses.AddRangeAsync(userCourses);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

    }

}
