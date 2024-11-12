using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class LoanerRequestDetail
    {
        public int LoanerRequestId { get; set; }
        public LoanerRequest LoanerRequest { get; set; }

        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        public int Quantity { get; set; }


        public DateTime ReturnDate { get; set; }

        [MaxLength(50)]
        public string ConditionOnReturn { get; set; }


    }
}
