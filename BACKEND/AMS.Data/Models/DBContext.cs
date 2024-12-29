using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AMS.Data.Models;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Approval> Approvals { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetImage> AssetImages { get; set; }

    public virtual DbSet<AssetType> AssetTypes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Depreciation> Depreciations { get; set; }

    public virtual DbSet<DepreciationImage> DepreciationImages { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<MaintenanceImage> MaintenanceImages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestDetail> RequestDetails { get; set; }

    public virtual DbSet<RequestDetailImage> RequestDetailImages { get; set; }

    public virtual DbSet<TransactionRecord> TransactionRecords { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=tcp:vocationalassetmanagement.database.windows.net,1433;Database=AssetManagementDB;MultipleActiveResultSets=true;User Id=johncop;Password=longphuc123@;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Approval>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Approvals_Id").IsDescending();

            entity.HasIndex(e => e.RequestId, "IX_Approvals_RequestId");

            entity.HasIndex(e => e.UserId, "IX_Approvals_UserId");

            entity.HasOne(d => d.Request).WithMany(p => p.Approvals)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Approvals).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasIndex(e => e.AssetTypeId, "IX_Assets_AssetTypeId");

            entity.HasIndex(e => e.DepartmentId, "IX_Assets_DepartmentId");

            entity.HasIndex(e => e.Id, "IX_Assets_Id").IsDescending();

            entity.HasIndex(e => e.LocationId, "IX_Assets_LocationId");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.AssetType).WithMany(p => p.Assets).HasForeignKey(d => d.AssetTypeId);

            entity.HasOne(d => d.Department).WithMany(p => p.Assets)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Location).WithMany(p => p.Assets).HasForeignKey(d => d.LocationId);
        });

        modelBuilder.Entity<AssetImage>(entity =>
        {
            entity.HasIndex(e => e.AssetId, "IX_AssetImages_AssetId");

            entity.HasIndex(e => e.Id, "IX_AssetImages_Id").IsDescending();

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetImages).HasForeignKey(d => d.AssetId);
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_AssetTypes_CategoryId");

            entity.HasIndex(e => e.Id, "IX_AssetTypes_Id").IsDescending();

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.AssetTypes).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Categories_Id").IsDescending();

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Departments_Id").IsDescending();
        });

        modelBuilder.Entity<Depreciation>(entity =>
        {
            entity.HasIndex(e => e.AssetId, "IX_Depreciations_AssetId");

            entity.HasIndex(e => e.DepreciationId, "IX_Depreciations_DepreciationId");

            entity.HasIndex(e => e.Id, "IX_Depreciations_Id").IsDescending();

            entity.Property(e => e.UsefulLife).HasMaxLength(50);

            entity.HasOne(d => d.Asset).WithMany(p => p.Depreciations).HasForeignKey(d => d.AssetId);

            entity.HasOne(d => d.DepreciationNavigation).WithMany(p => p.InverseDepreciationNavigation).HasForeignKey(d => d.DepreciationId);
        });

        modelBuilder.Entity<DepreciationImage>(entity =>
        {
            entity.HasIndex(e => e.DepreciationId, "IX_DepreciationImages_DepreciationId");

            entity.HasIndex(e => e.Id, "IX_DepreciationImages_Id").IsDescending();

            entity.HasOne(d => d.Depreciation).WithMany(p => p.DepreciationImages).HasForeignKey(d => d.DepreciationId);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Locations_Id").IsDescending();
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasIndex(e => e.AssetId, "IX_Maintenances_AssetId");

            entity.HasIndex(e => e.Id, "IX_Maintenances_Id").IsDescending();

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Asset).WithMany(p => p.Maintenances).HasForeignKey(d => d.AssetId);
        });

        modelBuilder.Entity<MaintenanceImage>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_MaintenanceImages_Id").IsDescending();

            entity.HasIndex(e => e.MaintenanceId, "IX_MaintenanceImages_MaintenanceId");

            entity.HasOne(d => d.Maintenance).WithMany(p => p.MaintenanceImages).HasForeignKey(d => d.MaintenanceId);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Notifications_Id").IsDescending();

            entity.HasIndex(e => e.RequestId, "IX_Notifications_RequestId");

            entity.HasIndex(e => e.UserId, "IX_Notifications_UserId");

            entity.Property(e => e.Message).HasMaxLength(500);

            entity.HasOne(d => d.Request).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Requests_Id").IsDescending();

            entity.HasIndex(e => e.RequesterId, "IX_Requests_RequesterId");

            entity.Property(e => e.Description).HasMaxLength(255);

            entity.HasOne(d => d.Requester).WithMany(p => p.Requests).HasForeignKey(d => d.RequesterId);
        });

        modelBuilder.Entity<RequestDetail>(entity =>
        {
            entity.HasIndex(e => e.AssetId, "IX_RequestDetails_AssetId");

            entity.HasIndex(e => e.Id, "IX_RequestDetails_Id").IsDescending();

            entity.HasIndex(e => e.NewLocationId, "IX_RequestDetails_NewLocationId");

            entity.HasIndex(e => e.RequestId, "IX_RequestDetails_RequestId");

            entity.Property(e => e.AssetOldLocation).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);

            entity.HasOne(d => d.Asset).WithMany(p => p.RequestDetails).HasForeignKey(d => d.AssetId);

            entity.HasOne(d => d.NewLocation).WithMany(p => p.RequestDetails).HasForeignKey(d => d.NewLocationId);

            entity.HasOne(d => d.Request).WithMany(p => p.RequestDetails).HasForeignKey(d => d.RequestId);
        });

        modelBuilder.Entity<RequestDetailImage>(entity =>
        {
            entity.ToTable("RequestDetailImage");

            entity.HasIndex(e => e.Id, "IX_RequestDetailImage_Id").IsDescending();

            entity.HasIndex(e => e.RequestDetailId, "IX_RequestDetailImage_RequestDetailId");

            entity.HasOne(d => d.RequestDetail).WithMany(p => p.RequestDetailImages).HasForeignKey(d => d.RequestDetailId);
        });

        modelBuilder.Entity<TransactionRecord>(entity =>
        {
            entity.HasIndex(e => e.AssetId, "IX_TransactionRecords_AssetId");

            entity.HasIndex(e => e.Id, "IX_TransactionRecords_Id").IsDescending();

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Asset).WithMany(p => p.TransactionRecords).HasForeignKey(d => d.AssetId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
