using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class DepreciationImage
{
    public int Id { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public int DepreciationId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Depreciation Depreciation { get; set; } = null!;
}
