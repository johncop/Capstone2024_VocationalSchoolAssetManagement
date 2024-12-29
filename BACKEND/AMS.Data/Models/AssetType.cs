using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class AssetType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual Category Category { get; set; } = null!;
}
