using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class Inventory : BaseEntity
    {
        [MaxLength(100)]
        public string LocationName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public int Capacity { get; set; }

    }
}
