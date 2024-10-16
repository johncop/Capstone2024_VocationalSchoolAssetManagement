using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Domain.Entities
{
    public class Depreciation : BaseEntity
    {
        public Asset AssetId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int PurchaseValue { get; set; }

        [MaxLength(50)]
        public string UsefulLife { get; set; }

        public string DepreciationRate { get; set; }

        public int Amount { get; set; }

        public int CurrentValue { get; set; }

        public int Year { get; set; }

    }
}
