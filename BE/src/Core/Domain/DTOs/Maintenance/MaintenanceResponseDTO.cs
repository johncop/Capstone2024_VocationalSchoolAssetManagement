namespace ASM.Core.DTOs.Maintaince;

public class MaintenanceResponseDTO
{
    public DateTime MaintenanceDate { get; set; }
    public string Description { get; set; }
    public int AssetId { get; set; }
}