using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class Asset
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? SerialNumber { get; set; }

    public int Status { get; set; }

    public int AssetTypeId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public int? DepartmentId { get; set; }

    public int? LocationId { get; set; }

    public bool IsBorrowable { get; set; }

    public bool IsDummy { get; set; }

    public string? Description { get; set; }

    public string? QrCodeUrl { get; set; }

    public bool IsExpendable { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<AssetImage> AssetImages { get; set; } = new List<AssetImage>();

    public virtual AssetType AssetType { get; set; } = null!;

    public virtual Department? Department { get; set; }

    public virtual ICollection<Depreciation> Depreciations { get; set; } = new List<Depreciation>();

    public virtual Location? Location { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();

    public virtual ICollection<TransactionRecord> TransactionRecords { get; set; } = new List<TransactionRecord>();
}
