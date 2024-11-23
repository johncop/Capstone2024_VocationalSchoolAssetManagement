namespace ASM.Core.BindingModels.Request;

public class CreateLoanRequestDetailBindingModel
{
    public int AssetId { get; set; }
    public string Description { get; set; }
    public DateTime ReturnDate { get; set; }
    public int Quantity { get; set; }

}
