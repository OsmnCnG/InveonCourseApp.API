using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Repositories;
using InveonCourseApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Service.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<List<AppUser>> GetAllUsers()
        {
            return await userRepository.GetAllAsync();
        }


        public async Task<AppUser> Select(Expression<Func<AppUser, bool>>? filter = null)
        {
            return await userRepository.FirstOrDefaultAsync(filter);
        }

        public async Task<bool> Any(Expression<Func<AppUser, bool>> filter)
        {
            return await userRepository.Any(filter);
        }


        public async Task<bool> CreateUser(AppUser appUser, string password)
        {
            return await userRepository.CreateAsync(appUser, password);
        }

        public async Task<bool> Delete(string id)
        {
            return await userRepository.Delete(id);
        }

        public async Task<bool> UpdateUser(int id, AppUser user)
        {
            return await userRepository.UpdateAsync(id,user); ;
        }

        public async Task<bool> AddRole(string roleName, int id)
        {
            return await userRepository.AddRole(roleName, id);
        }

        public async Task<bool> RemoveRole(string roleName, int id)
        {
            return await userRepository.RemoveRole(roleName, id);
        }


    }
}
