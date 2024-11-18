namespace ASM.Core.BindingModels.Inventory;

public class UpdateInventoryBindingModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
