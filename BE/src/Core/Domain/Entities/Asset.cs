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

        #region CONFIG RELATIONSHIP
        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public ICollection<Depreciation> Depreciations { get; set; }
        public ICollection<Maintenance> Maintainces { get; set; }
        public ICollection<AssetTransaction> Transactions { get; set; }
        public ICollection<AssetImage> Images { get; set; }
        #endregion
    }
}
