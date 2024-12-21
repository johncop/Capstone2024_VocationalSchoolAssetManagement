using ASM.Core.DTOs.Notification;
using ASM.Core.Entities;
using System.Linq.Expressions;

namespace ASM.Services.Interfaces
{
    public interface INotificationService
    {
        public Task<IList<NotificationResponseDTO>> GetAllAsync(Expression<Func<Notification, bool>>? filter = null,
            Expression<Func<Notification, object>>? includeEntities = null, bool disableChangeTracker = true);
    }
}
