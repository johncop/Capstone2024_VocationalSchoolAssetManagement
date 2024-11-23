namespace ASM.Core.Entities;

public class Approval
{
    public int LoanerRequestId { get; set; }
    public LoanRequest LoanRequest { get; set; }

    public int ApproverId { get; set; }
    public ApplicationUser Approver { get; set; }
    public DateTime ApprovalDate { get; set; }
}