using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.Maintaince
{
    public class MaintenanceBindingModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime MaintenanceDate { get; set; }
    }
}
