using ASM.Core.DTOs.Notification;
using ASM.Core.Entities;
using ASM.Repositories.Interfaces;
using ASM.Services.Interfaces;
using System.Linq.Expressions;

namespace ASM.Services.Services
{
    internal class NotificationService : INotificationService
    {
        private readonly IQueryRepository<Notification> _queryRepository;
        public NotificationService(IQueryRepository<Notification> queryRepository)
        {
            _queryRepository = queryRepository;
        }
        public async Task<IList<NotificationResponseDTO>> GetAllAsync(Expression<Func<Notification, bool>>? filter = null,
            Expression<Func<Notification, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            return await _queryRepository.GetAllAsync<NotificationResponseDTO>(filter, includeEntities, disableChangeTracker);
        }
    }
}
