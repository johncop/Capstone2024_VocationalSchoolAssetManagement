using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class Maintaince : BaseEntity
    {
        [MaxLength(500)]
        public string Description { get; set; }

        public int Status { get; set; }

        public DateTime MaintainceDate { get; set; }

        #region CONFIG RELATIONSHIP
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        #endregion
    }
}
