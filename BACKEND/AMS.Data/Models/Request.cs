using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class Request
{
    public int Id { get; set; }

    public int Status { get; set; }

    public DateTime RequestDate { get; set; }

    public int RequesterId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? RequestCode { get; set; }

    public int RequestType { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();

    public virtual AspNetUser Requester { get; set; } = null!;
}
