using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class TransactionRecord
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime RecordDate { get; set; }

    public string? LastLocation { get; set; }

    public string? CurrentLocation { get; set; }

    public int AssetId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Asset Asset { get; set; } = null!;
}
