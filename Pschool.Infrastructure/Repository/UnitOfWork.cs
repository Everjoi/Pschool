using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Exceptions;
using Pschool.Domain.Interfaces;
using Pschool.Infrastructure.Data.Contexts;
using System.Collections;


namespace Pschool.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PschoolPersonContext _dbContext;
        private readonly IMemoryCache _cache;
        private Hashtable _repositories;
        private bool disposed;

        public UnitOfWork(PschoolPersonContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _cache = cache;

            if (_repositories == null)
                _repositories = new Hashtable();
        }

        public IGenericRepository<T> Repository<T>() where T : class, IEntity
        {  
            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);
                _repositories.Add(type, repositoryInstance);
            }

            var repository = _repositories[type] as IGenericRepository<T>;

            return repository != null? repository : throw new RepositoryNotFoundException(type) ;
        }

        public async Task Rollback()
        {
            var changesEntities = await _dbContext.ChangeTracker.Entries().AsQueryable().ToListAsync();
            changesEntities.ForEach(x => x.ReloadAsync());

            return;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<IEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                        break;
                }
            }

            await SaveAndRemoveCache(cancellationToken);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            var changesCount = await _dbContext.SaveChangesAsync(cancellationToken);

            foreach (var key in cacheKeys)
            {
                _cache.Remove(key);
            }

            return changesCount;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }
            disposed = true;
        }
    }
}
