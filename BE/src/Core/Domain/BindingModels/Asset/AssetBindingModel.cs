namespace ASM.Core.BindingModels.Asset
{
    public class AssetBindingModel
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public bool IsBorrowable { get; set; }
        public bool IsDummy { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
