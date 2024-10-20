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

        #region CONFIG RELATIONSHIP
        public ICollection<Asset> Assets { get; set; }
        public ICollection<Category> Categories { get; set; }
        #endregion

    }
}
