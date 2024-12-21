using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Core.DTOs.RequestDetail
{
    public class RelocationDetailDTO
    {
        public int RequestDetailId { get; set; }
        public DateTime? ActualDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string AssetOldLocation { get; set; }
        public int? AssetNewLocationId { get; set; }

        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string SerialNumber { get; set; }

        public string LocationName { get; set; }
    }

}
