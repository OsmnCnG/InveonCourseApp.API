using InveonCourseApp.Core.Dtos;
using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Services;
using InveonCourseApp.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InveonCourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController(IProductService productService, UserCourseService userCourseService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var courses = await productService.GetAllAsync();

            return Ok(courses);
        }

        [HttpGet("GetCourseById")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await productService.GetByIdAsync(id);

            return Ok(course);
        }

        [HttpGet("CoursesWithCategory")]
        public async Task<IActionResult> GetCourseWithCategory()
        {
            return Ok(await productService.GetProductsWithCategory());
        }


        //[Authorize(Policy = "Instructor")]
        [HttpGet("CoursesByInstructor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetCourseByInstructorId(int id)
        {
            return Ok(await productService.Where(i=>i.InstructorUserId == id).ToListAsync());
        }

        [HttpPost("CreateCourse")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateCourse(CourseDto course)
        {
            var newProduct = new Product
            {
                Name = course.Name,
                Price = course.Price,
                Description = course.Description,
                CategoryId = course.CategoryId,
                InstructorUserId = course.InstructorUserId,
                Duration = course.Duration,
                ImageUrl = course.ImageUrl,
                Instructor = course.Instructor,
            };

            await productService.AddAsync(newProduct);
            
            return Ok(newProduct);
        }

        [HttpGet("UserCourses")]
        public async Task<IActionResult> GetUserCourses(int userId)
        {
            var courses = await userCourseService.GetUserCoursesAsync(userId);

            if (courses == null)
                return NotFound(new { Message = "Kullanıcı bulunamadı veya herhangi bir kurs listesi yok." });

            if (courses.Count == 0)
                return Ok(new List<CourseDto>());

            return Ok(courses);
        }

        [HttpPost("AddCourseToUser")]
        public async Task<IActionResult> AddCourseToUser(int userId, int productId)
        {
            var result = await userCourseService.AddCourseToUserAsync(userId, productId);

            if (!result)
                return BadRequest(new { Message = "Kurs eklenemedi. Kullanıcı veya kurs bulunamadı ya da zaten atanmış." });

            return Ok(new { Message = "Kurs kullanıcıya başarıyla eklendi." });
        }

        [HttpPost("AddCoursesToUser")]
        public async Task<IActionResult> AddCoursesToUser(int userId, List<int> productIds)
        {
            var result = await userCourseService.AddCoursesToUserAsync(userId, productIds);

            if (!result)
                return BadRequest(new { Message = "Kurslar eklenemedi. Kullanıcı veya kurs bulunamadı ya da zaten atanmış." });

            return Ok(new { Message = "Kurs kullanıcıya başarıyla eklendi." });
        }

    }
}
