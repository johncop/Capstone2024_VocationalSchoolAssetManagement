using ASM.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Core.Entities
{
    public class AssetTransaction : BaseEntity
    {
        public string Description { get; set; }
        public int Status { get; set; }

        public DateTime RecordDate { get; set; }
        public string LastLocation { get; set; }
        public string CurrentLocation {  get; set; }


        #region CONFIG RELATIONSHIP
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        #endregion
    }
}
