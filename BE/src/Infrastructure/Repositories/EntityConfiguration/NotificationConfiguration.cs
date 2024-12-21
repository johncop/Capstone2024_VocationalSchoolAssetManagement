using ASM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM.Database.EntityConfiguration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasOne(x => x.Request).WithMany(x => x.Notifications).HasForeignKey(x => x.RequestId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
