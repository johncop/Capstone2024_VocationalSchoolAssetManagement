namespace ASM.Core.BindingModels.Asset;

public class CreateAssetBindingModel
{
    public string Name { get; set; }
    public int SerialNumber { get; set; }
    public string Condition { get; set; }
    public int Status { get; set; }
    public int AssetTypeId { get; set; }
}
