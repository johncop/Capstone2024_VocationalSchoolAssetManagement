using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class AssetType : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        #region CONFIG RELATIONSHIP
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Asset> Assets { get; set; }
        #endregion
    }
}
