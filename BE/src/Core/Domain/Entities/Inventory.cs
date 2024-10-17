using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class Inventory : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public AssetType AssetType { get; set; }

        public Category CategoryId { get; set; }

    }
}
