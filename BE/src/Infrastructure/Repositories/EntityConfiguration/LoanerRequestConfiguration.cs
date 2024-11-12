using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration
{
    public class LoanerRequestConfiguration : IEntityTypeConfiguration<LoanerRequest>
    {
        public void Configure(EntityTypeBuilder<LoanerRequest> builder)
        {
            builder.HasMany(x => x.Approvals).WithOne(x => x.LoanerRequest).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
