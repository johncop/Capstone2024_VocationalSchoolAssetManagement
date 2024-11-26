using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class RequestDetailImage : BaseImageEntity
    {
        public int RequestDetailId { get; set; }
        public RequestDetail RequestDetail { get; set; }
    }
}
