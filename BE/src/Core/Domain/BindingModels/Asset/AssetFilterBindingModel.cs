using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.Asset
{
    public class AssetFilterBindingModel
    {
        public string Name { get; set; }
        public AssetStatusCollection Status { get; set; }
    }
}
