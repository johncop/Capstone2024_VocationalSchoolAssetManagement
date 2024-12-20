using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;

namespace ASM.Core.Entities
{
    public class Request : BaseEntity
    {
        public int Status { get; set; }

        public DateTime RequestDate { get; set; }

        public bool IsApproved { get; set; }
        public RequestTypeCollection RequestType { get; set; }
        public string RequestCode { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime ReceivedDate { get; set; }

        #region CONFIG  RELATIONSHIP
        public int RequesterId { get; set; }
        public ApplicationUser Requester { get; set; }

        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
        public ICollection<Approval> Approvals { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        #endregion
    }
}
