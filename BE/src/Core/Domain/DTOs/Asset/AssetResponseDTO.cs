using ASM.Core.DTOs.Department;
using ASM.Core.DTOs.Image;
using ASM.Core.DTOs.Location;


namespace ASM.Core.DTOs.Asset
{
    public class AssetResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public bool IsBorrowable { get; set; }
        public bool IsDummy { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public AssetTypeResponseDTO AssetType { get; set; }
        public LocationResponseDTO Location { get; set; }
        public DepartmentResponseDTO Department { get; set; }
        public IList<ImageResponseDTO> AssetImages { get; set; }
    }
}
