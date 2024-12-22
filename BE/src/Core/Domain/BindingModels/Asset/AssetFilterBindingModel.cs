using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.Asset
{
    public class AssetFilterBindingModel
    {
        public string Name { get; set; }
        public AssetStatusCollection? Status { get; set; }
        public string SerialNumber { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
