namespace ASM.Core.DTOs.AssetTranscation;

public class AssetTranscationResponseDTO
{
    public DateTime TranscationDate { get; set; }
    public string LastLocation { get; set; }
    public string NewLocation { get; set; }
    public string Description { get; set; }
    public int AssetId { get; set; }
}