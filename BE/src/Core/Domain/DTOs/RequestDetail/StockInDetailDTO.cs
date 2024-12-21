using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Core.DTOs.RequestDetail
{
    public class StockInDetailDTO
    {
        // Request Detail Fields
        public int RequestDetailId { get; set; }
        public DateTime? ActualDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string AssetOldLocation { get; set; }
        public int AssetNewLocationId { get; set; }

        // Asset Fields
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int AssetTypeId { get; set; }
        public string SerialNumber { get; set; }
        public int AssetStatus { get; set; }
        public string AssetDescription { get; set; }

        // Department Field
        public string DepartmentName { get; set; }

        // Location Field
        public string LocationName { get; set; }

        // Asset Type Field
        public string AssetTypeName { get; set; }
    }

}
