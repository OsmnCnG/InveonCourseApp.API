using InveonCourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Services
{
    public interface IUserService
    {
        Task<List<AppUser>> GetAllUsers();

        Task<AppUser> Select(Expression<Func<AppUser, bool>>? filter = null);

        Task<bool> Any(Expression<Func<AppUser, bool>> filter);

        Task<bool> CreateUser(AppUser appUser, string password);

        Task<bool> Delete(string id);

        Task<bool> UpdateUser(int id, AppUser user);

        Task<bool> AddRole(string roleName, int id);

        Task<bool> RemoveRole(string roleName, int id);

    }
}
