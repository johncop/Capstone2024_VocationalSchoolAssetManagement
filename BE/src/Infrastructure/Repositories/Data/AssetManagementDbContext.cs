using ASM.Core.Entities;
using ASM.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ASM.Database.Data
{
    public class AssetManagementDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options) : base(options) { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Approval> Approvals { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Maintaince> Maintainces { get; set; }
        public DbSet<Depreciation> Depreciations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<LoanerRequest> LoanerRequests { get; set; }
        public DbSet<LoanerRequestDetail> LoanerRequestDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AssetManagementDbContext).Assembly);
            base.OnModelCreating(builder);
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
