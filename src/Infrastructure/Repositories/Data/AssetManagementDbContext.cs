using ASM.Domain.Entities;
using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ASM.Database.Data
{
    public class AssetManagementDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AssetManagementDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        #region SUPPORT FUNC
        private void OnBeforeSaving()
        {
            IEnumerable<EntityEntry> entities = ChangeTracker.Entries();
            foreach (EntityEntry entity in entities)
            {
                if (entity.Entity is BaseEntity trackedEntity)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            trackedEntity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            trackedEntity.UpdatedDate = DateTime.Now;
                            break;
                    }
                }
            }
        }
        #endregion

    }
}
