using ASM.Core.Entities.Common;
using ASM.Core.Entities.Enum;

namespace ASM.Core.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationStatusCollection Status { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
