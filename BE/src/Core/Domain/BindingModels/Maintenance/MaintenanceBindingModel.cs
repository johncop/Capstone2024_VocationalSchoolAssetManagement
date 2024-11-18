namespace ASM.Core.BindingModels.Maintaince
{
    public class MaintenanceBindingModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime MaintenanceDate { get; set; }
    }
}
