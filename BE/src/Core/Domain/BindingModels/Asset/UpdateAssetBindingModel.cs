using Microsoft.AspNetCore.Http;

namespace ASM.Core.BindingModels.Asset
{
    public class UpdateAssetBindingModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public bool? IsBorrowable { get; set; }
        public bool? IsDummy { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? AssetTypeId { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public IList<IFormFile> Images { get; set; }
    }
}
