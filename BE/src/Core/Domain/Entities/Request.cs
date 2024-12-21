using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ASM.Core.Entities
{
    public class Request : BaseEntity
    {
        public int Status { get; set; }

        public DateTime RequestDate { get; set; }

        public RequestTypeCollection RequestType { get; set; }
        public string RequestCode { get; set; }
        [MaxLength(255), AllowNull]
        public string Description { get; set; }

        #region CONFIG  RELATIONSHIP
        public int RequesterId { get; set; }
        public ApplicationUser Requester { get; set; }

        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
        public ICollection<Approval> Approvals { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        #endregion
    }
}
