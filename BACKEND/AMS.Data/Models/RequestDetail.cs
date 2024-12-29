using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class RequestDetail
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public int AssetId { get; set; }

    public int AssetNewLocationId { get; set; }

    public DateTime ReturnDate { get; set; }

    public DateTime ActualReturnDate { get; set; }

    public string? AssetOldLocation { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public int Status { get; set; }

    public int? NewLocationId { get; set; }

    public DateTime ReceivedDate { get; set; }

    public int Quantity { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual Location? NewLocation { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual ICollection<RequestDetailImage> RequestDetailImages { get; set; } = new List<RequestDetailImage>();
}
