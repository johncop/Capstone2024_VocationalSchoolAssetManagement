using System.ComponentModel.DataAnnotations;
using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class TransactionRecord : BaseEntity
    {
        [MaxLength(255)]
        public string? Description { get; set; }

        public DateTime RecordDate { get; set; }

        [MaxLength(50)]
        public string LastLocation { get; set; }

        [MaxLength(50)]
        public string CurrentLocation { get; set; }


        #region CONFIG RELATIONSHIP
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        #endregion
    }
}
