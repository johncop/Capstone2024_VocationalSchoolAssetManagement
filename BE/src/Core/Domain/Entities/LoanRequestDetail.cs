using System.ComponentModel.DataAnnotations;
using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class LoanRequestDetail : BaseEntity
    {
        public int LoanRequestId { get; set; }
        public LoanRequest LoanRequest { get; set; }

        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        public int Quantity { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }

        [MaxLength(50)]
        public string ConditionOnReturn { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public ICollection<LoanRequestDetailImage> Images { get; set; }
    }
}
