using Microsoft.AspNetCore.Http;

namespace ASM.Core.BindingModels.Asset
{
    public class UpdateAssetBindingModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SerialNumber { get; set; }
        public string? Condition { get; set; }
        public int? Status { get; set; }
        public int? AssetTypeId { get; set; }
        public IList<IFormFile> Images { get; set; }
    }
}
