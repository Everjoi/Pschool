using Microsoft.EntityFrameworkCore;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Exceptions;
using Pschool.Domain.Interfaces;
using Pschool.Infrastructure.Data.Contexts;


namespace Pschool.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly PschoolPersonContext _dbContext;

        public GenericRepository(PschoolPersonContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            if (await _dbContext.Set<T>().AnyAsync(x => x.Id == entity.Id))
                throw new AlreadyExistException(typeof(T), entity.Id);

            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            if (! await _dbContext.Set<T>().AnyAsync(x => x.Id == entity.Id))
                throw new NotFoundException(typeof(T), entity.Id);

            T? exist = _dbContext.Set<T>().Find(entity.Id);

            if(exist != null)
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);

            return;
        }

        public async Task DeleteAsync(T entity)
        {
            if (!await _dbContext.Set<T>().AnyAsync(x => x.Id == entity.Id))
                throw new NotFoundException(typeof(T), entity.Id);

            _dbContext.Set<T>().Remove(entity);
            return;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            if (result == null)
                throw new NotFoundException(typeof(T), id);

            return result;
        }
    }
}
