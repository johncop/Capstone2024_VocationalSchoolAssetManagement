
using AMS.Core.CustomAttribute;
using AMS.Data.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace AMS.Core._Repositories.Interfaces
{
    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface IRepositoryAccessor
    {
        Task<bool> Save();
        Task<IDbContextTransaction> BeginTransactionAsync();

        IRepository<Location> Location { get; }
        IRepository<Department> Department { get; }
        IRepository<Category> Category { get; }
    }
}