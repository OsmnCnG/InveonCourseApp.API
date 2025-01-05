using InveonCourseApp.Core.Dtos;
using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InveonCourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : Controller
    {
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllUsers());
        }


        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var dUser = await userService
        //        .Select(m => m.Id == id);


        //    if (dUser == null)
        //    {
        //        return RedirectToAction("GetAllUsers", "User");
        //    }

        //    //var result = await userManager.DeleteAsync(dUser);


        //    var result = await userService.Delete(dUser.Id.ToString());

        //    if (!result)
        //    {
        //        return RedirectToAction("GetAllUsers", "User");
        //    }

        //    return RedirectToAction("GetAllUsers", "User");
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateUser(int id)
        //{
        //    return View(await userService.Select(u => u.Id == id));
        //}

        [HttpPost("UpdateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            var upd = new AppUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
            };

            var result = await userService.UpdateUser(id, upd);

            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {

            if (await userService.Any(e => e.Email == userDto.Email))
            {
                return BadRequest("email exist");
            }

            var newUser = new AppUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                PasswordHash = userDto.Password
            };

            var identityResult = await userService.CreateUser(newUser, userDto.Password);


            if (!identityResult)
            {
                return RedirectToAction("GetAllUsers");
            }

            return Ok();

        }
    }
}
