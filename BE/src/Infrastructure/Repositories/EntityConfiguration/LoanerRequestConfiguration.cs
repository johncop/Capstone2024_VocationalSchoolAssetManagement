using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration;

public class LoanerRequestConfiguration : IEntityTypeConfiguration<LoanRequest>
{
    public void Configure(EntityTypeBuilder<LoanRequest> builder)
    {
        builder.HasMany(x => x.Approvals).WithOne(x => x.LoanRequest).OnDelete(DeleteBehavior.ClientCascade);
    }
}