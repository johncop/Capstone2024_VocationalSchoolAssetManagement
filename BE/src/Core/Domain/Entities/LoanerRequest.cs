using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class LoanerRequest : BaseEntity
    {
        public int Status { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime ApprovedDate { get; set; }

        public int IsApproved { get; set; }

        #region CONFIG  RELATIONSHIP
        public int RequesterId { get; set; }
        public ApplicationUser Requester { get; set; }
        public ICollection<LoanerRequestDetail> LoanerRequestDetails { get; set; }
        public ICollection<Approval> Approvals { get; set; }
        #endregion
    }
}
