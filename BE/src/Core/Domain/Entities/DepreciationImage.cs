using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class DepreciationImage : BaseEntity
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

        #region CONFIG RELATIONSHIP
        public int DepreciationId { get; set; }
        public Depreciation Depreciation { get; set; }
        #endregion
    }
}
