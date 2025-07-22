namespace DevSkill.Inventory.Web.Areas.Admin.Models.ProductPlusModels
{
    public class ProductPlusAddViewModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal MRP { get; set; }
        public decimal WholesalePrice { get; set; }
        public int StockQuantity { get; set; }
        public int LowStockThreshold { get; set; }
        public int DamageStock { get; set; }
        public IFormFile? ProductImage { get; set; }
    }
}
