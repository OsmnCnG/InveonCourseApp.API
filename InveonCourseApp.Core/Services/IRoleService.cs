using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Services
{
    public interface IRoleService
    {
        Task<bool> CreateRole(string roleName);
        Task<bool> DeleteRole(int id);
        Task<List<AppRole>> GetAllRoles();
    }
    
}
