namespace ASM.Core.DTOs.RequestDetail
{
    public class RequestAssetDTOs
    {
        public int RequestId {  get; set; } 
        public int RequestDetailId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int AssetType { get; set; }
        public string SerialNumber { get; set; }
    }
}
