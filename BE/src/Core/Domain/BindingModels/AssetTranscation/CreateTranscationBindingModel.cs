using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.AssetTranscation;

public class CreateTranscationBindingModel
{
    public int AssetId { get; set; }
    public string Description { get; set; }
    public string LastLocation { get; set; }
    public string CurrentLocation { get; set; }

    public DateTime RecordDate { get; set; }

}
