namespace ASM.Core.BindingModels.AssetType;

public class CreateAssetTypeBindingModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
}
