namespace ASM.Core.BindingModels.Request
{
    public class UpdateRequestBindingModel
    {
        public int Id { get; set; }
        public int? Status { get; set; }

        public DateTime? RequestDate { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public bool? IsApproved { get; set; }

        public IList<CreateRequestDetailBindingModel> Details { get; set; }
    }
}
