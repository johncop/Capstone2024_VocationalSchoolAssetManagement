using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Domain.Entities
{
    public class Maintaince : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int Status { get; set; }

        public DateTime MaintainceDate { get; set; }


    }
}
