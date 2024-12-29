using AMS.Core._Repositories.Interfaces;
using AMS.Data;
using AMS.Data.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace AMS.Core._Repositories.Repositories
{
    public class RepositoryAccessor : IRepositoryAccessor
    {
        private DBContext _dbContext;
        public RepositoryAccessor(DBContext dbContext)
        {
            _dbContext = dbContext;

            Location = new Repository<Location, DBContext>(_dbContext);
            Department = new Repository<Department, DBContext>(_dbContext);
            Category = new Repository<Category, DBContext>(_dbContext);


        }

        public IRepository<Location> Location { get; set; }
        public IRepository<Department> Department { get; set; }
        public IRepository<Category> Category { get; set; }


        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }
    }
}