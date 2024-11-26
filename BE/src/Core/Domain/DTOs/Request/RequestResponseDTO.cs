namespace ASM.Core.DTOs.Request
{
    public class RequestResponseDTO
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool IsApproved { get; set; }
        public ICollection<RequestDetailResponseDTO> Details { get; set; }
    }
}
