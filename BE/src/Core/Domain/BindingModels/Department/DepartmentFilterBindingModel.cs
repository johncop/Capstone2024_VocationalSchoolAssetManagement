using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.Department
{
    public class DepartmentFilterBindingModel
    {
        public string Name { get; set; }
        public DepartmentStatusCollection? Status { get; set; }
    }
}
