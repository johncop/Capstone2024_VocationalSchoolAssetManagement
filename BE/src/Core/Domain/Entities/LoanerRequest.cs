using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class LoanerRequest : BaseEntity
    {
        public int Status { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime ApprovedDate { get; set; }

        public int IsApproved { get; set; }

    }
}
