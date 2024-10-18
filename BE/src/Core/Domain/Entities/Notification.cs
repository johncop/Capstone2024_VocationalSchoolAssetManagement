using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class Notification : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Message { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }

        public int Status { get; set; }

        public DateTime ExpiredAt { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
