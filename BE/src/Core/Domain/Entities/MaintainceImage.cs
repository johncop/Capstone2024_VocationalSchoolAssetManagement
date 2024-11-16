using ASM.Core.Entities.Common;

namespace ASM.Core.Entities
{
    public class MaintenanceImage : BaseEntity
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

        #region CONFIG RELATIONSHIP
        public int MaintenanceId { get; set; }
        public Maintenance Maintenance { get; set; }
        #endregion
    }
}
