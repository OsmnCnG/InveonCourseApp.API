using InveonCourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<bool> RoleCreate(string roleName);

        Task<List<AppRole>> GetAllRoles();

        Task<bool> RoleDelete(int id);

    }
}
