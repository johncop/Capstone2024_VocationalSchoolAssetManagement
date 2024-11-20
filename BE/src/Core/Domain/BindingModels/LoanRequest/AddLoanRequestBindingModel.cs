namespace ASM.Core.BindingModels.Request;

public class AddLoanRequestBindingModel
{
    public string Description { get; set; }
    public int UserId { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.Now;
    public int Status { get; set; }
    public ICollection<AddLoanRequestDetailBindingModel> Details { get; set; }
}
