using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class Maintenance : BaseEntity
    {
        [MaxLength(500)]
        public string Description { get; set; }


        public DateTime MaintenanceDate { get; set; }

        #region CONFIG RELATIONSHIP
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public ICollection<MaintenanceImage> Images { get; set; }
        #endregion
    }
}
