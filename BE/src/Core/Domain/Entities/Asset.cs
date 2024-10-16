using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class Asset : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public int SerialNumber { get; set; }

        [MaxLength(100)]
        public string Condition { get; set; }

        public int Status { get; set; }
        public AssetType AssetTypeId { get; set; }
        public Inventory InventoryId { get; set; }
    }
}
