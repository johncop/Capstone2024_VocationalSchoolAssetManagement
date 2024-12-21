using System.ComponentModel.DataAnnotations;
using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;

namespace ASM.Core.Entities
{
    public class Notification : BaseEntity
    {
        [MaxLength(500)] public string Message { get; set; }

        public NotificationStatusCollection Status { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int RequestId {  get; set; }
        public Request Request { get; set; }
    }
}
