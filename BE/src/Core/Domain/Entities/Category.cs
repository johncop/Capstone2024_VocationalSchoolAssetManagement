using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class Category : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        #region CONFIG RELATIONSHIP
        public ICollection<AssetType> AssetTypes { get; set; }
        #endregion
    }
}
