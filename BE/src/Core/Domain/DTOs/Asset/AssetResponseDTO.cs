namespace ASM.Core.DTOs.Asset;

public class AssetResponseDTO
{
    public string Name { get; set; }
    public int SerialNumber { get; set; }
    public string Condition { get; set; }
    public int Status { get; set; }
    public AssetTypeResponseDTO AssetType { get; set; }
}
