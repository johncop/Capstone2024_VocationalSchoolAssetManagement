using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasOne(x => x.Department).WithMany(x => x.Assets).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
