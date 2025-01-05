using InveonCourseApp.Core.Dtos;
using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace InveonCourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryService.GetAllAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {

            var newCategory = new Category
            {
                Name = categoryDto.Name,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            await categoryService.AddAsync(newCategory);

            return Ok(newCategory);
        }
    }
}
