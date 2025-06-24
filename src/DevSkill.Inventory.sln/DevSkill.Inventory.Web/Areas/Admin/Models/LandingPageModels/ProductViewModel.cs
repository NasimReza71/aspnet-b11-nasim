namespace DevSkill.Inventory.Web.Areas.Admin.Models.LandingPageModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string StockUnit { get; set; } 
        public int TodaySale { get; set; }
        public string SaleUnit { get; set; }
    }
}
