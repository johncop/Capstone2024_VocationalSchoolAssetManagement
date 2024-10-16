using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Domain.Entities
{
    public class Notification : BaseEntity
    {

        public ApplicationUser UserId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Message { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }

        public int Status { get; set; }

        public DateTime ExpiredAt { get; set; }


    }
}
