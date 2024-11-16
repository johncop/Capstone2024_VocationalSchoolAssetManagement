using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class AssetImage : BaseEntity
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

        #region CONFIG RELATIONSHIP
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        #endregion
    }
}
