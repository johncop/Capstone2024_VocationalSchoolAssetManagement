namespace ASM.Core.Entities
{
    public class AssetInventory
    {
        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public int Quantity { get; set; }

    }
}
