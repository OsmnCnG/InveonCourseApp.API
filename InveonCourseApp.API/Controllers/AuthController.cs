using InveonCourseApp.API.Helpers;
using InveonCourseApp.API.Model;
using InveonCourseApp.API.Security;
using InveonCourseApp.Core.Dtos;
using InveonCourseApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Xml.Linq;

namespace InveonCourseApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<AppUser> userManager ,RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IConfiguration configuration) : Controller
    {

        [HttpPost("Login")]
        public async Task<ResponseBase<object>> Login(LoginDto loginDto)
        {
            var rt = new ResponseBase<object>();

            var authUser = await userManager.FindByEmailAsync(loginDto.Email);

            if (authUser != null)
            {
                var checkUserPassword = await signInManager.CheckPasswordSignInAsync(authUser,loginDto.Password,false);

                if (!checkUserPassword.Succeeded) {
                    rt.IsSuccess = false;
                    rt.Message = "Şifre yanlış";
                    return rt;
                }

                rt.IsSuccess = true;
                authUser.LastLoginDate = DateTime.Now;
                await userManager.UpdateAsync(authUser);

                var roleInstructor = await userManager.IsInRoleAsync(authUser,"Instructor");
                if(roleInstructor)
                {
                    authUser.Authority = new List<string> { "Instructor" };
                }
                rt.Data = authUser;
                var authClaims = new List<Claim>
                {
                    new Claim("UserName", authUser.Email),
                    new Claim("UserID", value: authUser.Id.ToString()),

                };
                Token token = JwtHelper.CreateToken(configuration, authClaims);

                rt.Token = token;
            }
            else
            {
                rt.IsSuccess = false;
                rt.Message = "Kullanıcı Bulunamadı";
            }


            return rt;
        }
    }
}
