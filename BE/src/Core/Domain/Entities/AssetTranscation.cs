using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class TransactionRecord : BaseEntity
    {
        [MaxLength(500)]
        public string Description { get; set; }
        public string LastLocation { get; set; }
        public string CurrentLocation { get; set; }

        public DateTime RecordDate { get; set; }

        #region CONFIG RELATIONSHIP
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        #endregion
    }
}
