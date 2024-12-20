using System.ComponentModel.DataAnnotations;
using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;

namespace ASM.Core.Entities
{
    public class Asset : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public int SerialNumber { get; set; }

        [MaxLength(100)]
        public string Condition { get; set; }

        public AssetStatusCollection Status { get; set; }
        public bool IsBorrowable { get; set; }
        public bool IsDummy { get; set; }

        #region CONFIG RELATIONSHIP
        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }

        public ICollection<Depreciation> Depreciations { get; set; }
        public ICollection<Maintenance> Maintainces { get; set; }
        public ICollection<TransactionRecord> Transactions { get; set; }
        public ICollection<AssetImage> Images { get; set; }
        #endregion
    }
}
