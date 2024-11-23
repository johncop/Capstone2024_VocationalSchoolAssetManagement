using ASM.Core.Entities.Common;

namespace ASM.Core.Entities;

public class LoanRequestDetailImage : BaseImageEntity
{
    public int LoanRequestDetailId { get; set; }
    public LoanRequestDetail LoanRequestDetail { get; set; }
}
