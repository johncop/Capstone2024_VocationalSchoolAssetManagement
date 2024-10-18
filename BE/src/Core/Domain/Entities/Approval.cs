using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Core.Entities
{
    public class Approval
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public LoanerRequest RequestId { get; set; }

        public string ApprovedBy { get; set; }

        public DateTime ApprovalDate { get; set; }

    }
}
