namespace ASM.Core.DTOs.Request
{
    public class RequestDetailResponseDTO
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public string ConditionOnReturn { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
