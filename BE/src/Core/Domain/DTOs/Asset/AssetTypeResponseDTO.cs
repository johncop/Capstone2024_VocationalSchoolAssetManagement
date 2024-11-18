using ASM.Core.DTOs.Category;

namespace ASM.Core.DTOs.Asset;

public class AssetTypeResponseDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Quantity { get; set; }
    public CategoryResponseDTO Category { get; set; }
}
