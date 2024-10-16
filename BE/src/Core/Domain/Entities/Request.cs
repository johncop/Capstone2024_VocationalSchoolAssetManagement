using Domain.Entities.Common;

namespace ASM.Domain.Entities
{
    public class Request : BaseEntity
    {

        public ApplicationUser UserId { get; set; }

        public int Status { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime ApprovedDate { get; set; }

        public int IsApproved { get; set; }

    }
}
