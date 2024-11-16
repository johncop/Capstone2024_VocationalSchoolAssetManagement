namespace ASM.Core.BindingModels.Maintaince
{
    public class MaintainceBindingModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime MaintainceDate { get; set; }
    }
}
