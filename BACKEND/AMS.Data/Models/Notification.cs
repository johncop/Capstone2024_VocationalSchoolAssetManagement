using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public int Status { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public int RequestId { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
