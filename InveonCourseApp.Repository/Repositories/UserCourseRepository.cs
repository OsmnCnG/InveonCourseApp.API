using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Repository.Repositories
{
    public class UserCourseRepository : GenericRepository<UserCourse>
    {
        private readonly ApplicationDbContext _appDbContext;
        public UserCourseRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
