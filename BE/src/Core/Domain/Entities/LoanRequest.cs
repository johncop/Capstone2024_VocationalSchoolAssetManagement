using ASM.Core.Entities.Common;

namespace ASM.Core.Entities;

public class LoanRequest : BaseEntity
{
    public int Status { get; set; }

    public DateTime RequestDate { get; set; }

    public bool IsApproved { get; set; }

    #region CONFIG  RELATIONSHIP

    public int RequesterId { get; set; }
    public ApplicationUser Requester { get; set; }

    public ICollection<LoanRequestDetail> LoanerRequestDetails { get; set; }
    public ICollection<Approval> Approvals { get; set; }
    public ICollection<Notification> Notifications { get; set; }

    #endregion
}