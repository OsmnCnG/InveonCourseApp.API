using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Repository.Repositories
{
    public class RoleRepository(RoleManager<AppRole> roleManager) : IRoleRepository
    {
        public async Task<bool> RoleCreate(string roleName)
        {
            var IsRoleExist = await roleManager.RoleExistsAsync(roleName);

            if (IsRoleExist)
            {
                return false;
            }

            AppRole role = new AppRole()
            {
                Name = roleName,
            };

            await roleManager.CreateAsync(role);

            return true;

        }


        public async Task<List<AppRole>> GetAllRoles()
        {

            var roles = await roleManager.Roles.ToListAsync();

            return roles;

        }

        public async Task<bool> RoleDelete(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                return false;

            }

            if (role.Name == "Admin")
            {
                return false;

            }

            var result = await roleManager.DeleteAsync(role);

            if (result == null || !result.Succeeded)
            {
                return false;

            }

            return true;

        }

    }
}
