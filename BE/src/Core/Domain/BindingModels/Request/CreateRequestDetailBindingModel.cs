namespace ASM.Core.BindingModels.Request;

public class CreateRequestDetailBindingModel
{
    public int AssetId { get; set; }
    public string Description { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime ActualReturnDate { get; set; }
    public DateTime ReceivedDate { get; set; }
    public string AssetOldLocation { get; set; }
    public int AssetNewLocationId { get; set; }

}
