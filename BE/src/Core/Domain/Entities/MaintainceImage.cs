using ASM.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Core.Entities
{
    public class MaintainceImage : BaseEntity
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

        #region CONFIG RELATIONSHIP
        public int MaintainceId { get; set; }
        public Maintaince Maintaince { get; set; }
        #endregion
    }
}
