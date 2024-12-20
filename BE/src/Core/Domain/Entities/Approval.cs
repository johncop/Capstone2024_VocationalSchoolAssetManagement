using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;

namespace ASM.Core.Entities
{
    public class Approval : BaseEntity
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int ApproverId { get; set; }
        public ApplicationUser Approver { get; set; }
        public DateTime ApprovalDate { get; set; }
        public ApprovalStatusCollection ApprovalStatus { get; set; }
    }
}
