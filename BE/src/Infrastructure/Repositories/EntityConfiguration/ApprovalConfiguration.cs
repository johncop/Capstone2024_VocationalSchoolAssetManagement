using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration
{
    public class ApprovalConfiguration : IEntityTypeConfiguration<Approval>
    {
        public void Configure(EntityTypeBuilder<Approval> builder)
        {
            builder.HasKey(x => new { x.LoanerRequestId, x.ApproverId });
        }
    }
}
