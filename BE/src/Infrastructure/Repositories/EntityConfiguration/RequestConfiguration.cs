using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasMany(x => x.Approvals).WithOne(x => x.Request).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
