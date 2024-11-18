using ASM.Core.Entities.Common;

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
