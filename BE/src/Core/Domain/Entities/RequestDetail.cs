using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;

namespace ASM.Core.Entities
{
    public class RequestDetail : BaseEntity
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public DateTime ReceivedDate { get; set; }

        [MaxLength(255), AllowNull]
        public string Description { get; set; }
        public DetailStatusCollection Status { get; set; }
        [MaxLength(50), AllowNull]
        public string AssetOldLocation {  get; set; }
        [AllowNull]
        public int AssetNewLocationId { get; set; }
        public Location NewLocation { get; set; }
        public ICollection<RequestDetailImage> Images { get; set; }
    }
}
