using ASM.Database.Data;
using ASM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ASM.Repositories.Repositories
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        protected readonly AssetManagementDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public CommandRepository(AssetManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Add(params TEntity[] entities)
        {

        }

        public void Update(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        private void PerformDbOperation(Func<TEntity, EntityEntry<TEntity>> dbOperation, params TEntity[] entities)
        {
            if (dbOperation == null)
            {
                throw new ArgumentNullException(nameof(dbOperation));
            }

            if (entities == null || entities.Any(x => x == null))
            {
                throw new ArgumentException(nameof(entities));
            }

            foreach (TEntity entity in entities)
            {
                dbOperation(entity);
            }

        }
    }
}
