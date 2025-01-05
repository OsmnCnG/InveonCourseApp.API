using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Repositories;
using InveonCourseApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Service.Services
{
    public class RoleService(IRoleRepository roleRepository) : IRoleService
    {
        public async Task<bool> CreateRole(string roleName)
        {
            return await roleRepository.RoleCreate(roleName);
        }

        public async Task<bool> DeleteRole(int id)
        {
            return await roleRepository.RoleDelete(id);
        }

        public async Task<List<AppRole>> GetAllRoles()
        {
            return await roleRepository.GetAllRoles();
        }
    }
}
