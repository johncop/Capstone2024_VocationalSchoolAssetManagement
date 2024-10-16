using System.ComponentModel.DataAnnotations;

namespace ASM.Domain.Entities
{
    public class RequestDetails
    {

        public Request RequestId { get; set; }

        public Asset AssetId { get; set; }

        public int Quantity { get; set; }


        public DateTime ReturnDate { get; set; }

        [MaxLength(50)]
        public string ConditionOnReturn { get; set; }


    }
}
