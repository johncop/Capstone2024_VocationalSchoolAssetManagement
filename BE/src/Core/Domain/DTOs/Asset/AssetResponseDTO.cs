using ASM.Core.DTOs.Image;

namespace ASM.Core.DTOs.Asset
{
    public class AssetResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public string Condition { get; set; }
        public int Status { get; set; }
        public AssetTypeResponseDTO AssetType { get; set; }
        public IList<ImageResponseDTO> AssetImages { get; set; }
    }
}
