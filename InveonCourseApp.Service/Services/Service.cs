using InveonCourseApp.Core.Repositories;
using InveonCourseApp.Core.Services;
using InveonCourseApp.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InveonCourseApp.Service.Services
{
    public class Service<TEntity>(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork) : IService<TEntity> 
        where TEntity : class
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await repository.AddAsync(entity);

            await unitOfWork.SaveAsync();

            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await repository.AnyAsync(filter);
        }

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return repository.FirstOrDefault(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAll().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public void RemoveAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        {
            return repository.Where(filter);
        }
    }
}
