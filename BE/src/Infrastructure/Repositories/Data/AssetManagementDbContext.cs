using ASM.Core.Entities;
using ASM.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace ASM.Database.Data
{
    public class AssetManagementDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options) : base(options) { }

        public DbSet<Asset> Asset { get; set; }
        public DbSet<Approval> Approval { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Maintaince> Maintaince { get; set; }
        public DbSet<Depreciation> Depreciation { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<LoanerRequest> Request { get; set; }
        public DbSet<LoanerRequestDetail> RequestDetails { get; set; }

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
