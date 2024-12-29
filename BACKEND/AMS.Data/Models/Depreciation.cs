using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class Depreciation
{
    public int Id { get; set; }

    public DateTime PurchaseDate { get; set; }

    public int PurchaseValue { get; set; }

    public string? UsefulLife { get; set; }

    public string? DepreciationRate { get; set; }

    public int Amount { get; set; }

    public int CurrentValue { get; set; }

    public int Year { get; set; }

    public int AssetId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public int? DepreciationId { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual ICollection<DepreciationImage> DepreciationImages { get; set; } = new List<DepreciationImage>();

    public virtual Depreciation? DepreciationNavigation { get; set; }

    public virtual ICollection<Depreciation> InverseDepreciationNavigation { get; set; } = new List<Depreciation>();
}
