using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.Maintenance;

public class CreateMaintenanceBindingModel
{
    public DateTime MaintenanceDate { get; set; } = DateTime.Now;
    public string Description { get; set; }
    public int AssetId { get; set; }

}
