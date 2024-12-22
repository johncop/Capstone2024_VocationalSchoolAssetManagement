using ASM.Core.Entities.Enum;

namespace ASM.Core.BindingModels.Request
{
    public class CreateRequestBindingModel
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public RequestTypeCollection RequestTypes { get; set; }
        public ICollection<CreateRequestDetailBindingModel> Details { get; set; }
    }
}
