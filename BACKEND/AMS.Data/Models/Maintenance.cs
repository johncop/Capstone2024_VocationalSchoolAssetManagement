using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class Maintenance
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime MaintenanceDate { get; set; }

    public int AssetId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual ICollection<MaintenanceImage> MaintenanceImages { get; set; } = new List<MaintenanceImage>();
}
