using ASM.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class RequestDetails : BaseEntity
    {
        public Request RequestId { get; set; }

        public Asset AssetId { get; set; }

        public int Quantity { get; set; }


        public DateTime ReturnDate { get; set; }

        [MaxLength(50)]
        public string ConditionOnReturn { get; set; }


    }
}
