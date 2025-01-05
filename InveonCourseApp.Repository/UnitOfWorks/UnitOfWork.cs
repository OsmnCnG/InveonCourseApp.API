using InveonCourseApp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Repository.UnitOfWorks
{
    public class UnitOfWork(ApplicationDbContext appDbContext) : IUnitOfWork
    {
        public void Dispose()
        {
            appDbContext.Dispose();
        }

        public void Save()
        {
            appDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
