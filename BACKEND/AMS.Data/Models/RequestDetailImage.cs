using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class RequestDetailImage
{
    public int Id { get; set; }

    public int RequestDetailId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public virtual RequestDetail RequestDetail { get; set; } = null!;
}
