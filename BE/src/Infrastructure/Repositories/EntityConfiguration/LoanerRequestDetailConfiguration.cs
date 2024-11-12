using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration
{
    public class LoanerRequestDetailConfiguration : IEntityTypeConfiguration<LoanerRequestDetail>
    {
        public void Configure(EntityTypeBuilder<LoanerRequestDetail> builder)
        {
            builder.HasKey(x => new { x.AssetId, x.LoanerRequestId });
        }
    }
}
