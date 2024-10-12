using ASM.Database.Data;
using ASM.Repositories.Interfaces;

namespace ASM.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssetManagementDbContext _dbContext;
        public UnitOfWork(AssetManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
