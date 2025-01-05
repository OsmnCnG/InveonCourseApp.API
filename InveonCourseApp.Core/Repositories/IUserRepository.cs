using InveonCourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserByIdAsync(int id);

        Task<List<AppUser>> GetAllAsync();

        Task<AppUser> FirstOrDefaultAsync(Expression<Func<AppUser, bool>>? filter = null);

        Task<bool> Any(Expression<Func<AppUser, bool>> filter);

        Task<bool> CreateAsync(AppUser newUser, string password);

        Task<bool> Delete(string id);

        Task<bool> UpdateAsync(int id, AppUser user);

        Task<bool> AddRole(string roleName, int id);

        Task<bool> RemoveRole(string roleName, int id);


    }
}
