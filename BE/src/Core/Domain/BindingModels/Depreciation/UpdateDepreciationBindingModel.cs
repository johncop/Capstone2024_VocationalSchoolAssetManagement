namespace ASM.Core.BindingModels.Depreciation;

public class UpdateDepreciationBindingModel
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int PurchaseValue { get; set; }
    public string UsefulLife { get; set; }
    public string DepreciationRate { get; set; }
    public int Amount { get; set; }
    public int CurrentValue { get; set; }
    public int Year { get; set; }
}
