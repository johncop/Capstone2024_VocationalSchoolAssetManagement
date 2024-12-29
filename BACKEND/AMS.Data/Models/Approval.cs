using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class Approval
{
    public int ApproverId { get; set; }

    public DateTime ApprovalDate { get; set; }

    public int RequestId { get; set; }

    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
