using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
        void Save();
    }
}
