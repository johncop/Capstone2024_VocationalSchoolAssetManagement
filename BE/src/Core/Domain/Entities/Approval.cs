namespace ASM.Core.Entities
{
    public class Approval
    {
        public int LoanerRequestId { get; set; }
        public LoanerRequest LoanerRequest { get; set; }

        public int ApproverId { get; set; }
        public ApplicationUser Approver { get; set; }
        public DateTime ApprovalDate { get; set; }
    }
}
