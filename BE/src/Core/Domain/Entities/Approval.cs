namespace ASM.Core.Entities
{
    public class Approval
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int ApproverId { get; set; }
        public ApplicationUser Approver { get; set; }
        public DateTime ApprovalDate { get; set; }
    }
}
