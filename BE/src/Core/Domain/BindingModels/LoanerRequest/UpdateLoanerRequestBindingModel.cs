namespace ASM.Core.BindingModels.Request;

public class UpdateLoanerRequestBindingModel
{
    public int Id { get; set; }
    public int? Status { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public int? IsApproved { get; set; }
}
