using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration
{
    public class ApprovalConfiguration : IEntityTypeConfiguration<Approval>
    {
        public void Configure(EntityTypeBuilder<Approval> builder)
        {
            builder.HasOne(x => x.Request).WithMany(x => x.Approvals).HasForeignKey(x => x.RequestId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
