using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.Location
{
    public class LocationFilterBindingModel
    {
        public string Name { get; set; }
        public LocationStatusCollection? Status { get; set; }
    }
}
