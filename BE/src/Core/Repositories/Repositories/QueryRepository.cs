using ASM.Database.Data;
using ASM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASM.Repositories.Repositories
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
    {
        protected readonly AssetManagementDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public QueryRepository(AssetManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            return InitQuery(filter, includeEntities, disableChangeTracker);
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            return InitQuery(filter, includeEntities, disableChangeTracker).ToList();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            return await InitQuery(filter, includeEntities, disableChangeTracker).ToListAsync();
        }

        public IQueryable<TEntity> InitQuery(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeEntities != null)
            {
                query.Include(includeEntities);
            }

            if (disableChangeTracker)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
    }
}
