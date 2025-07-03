namespace DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels
{
    public class PurchaseSearchModel
    {
        public string PurchaseInvoice { get; set; }
        public string Name { get; set; }
        public string Products { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Due { get; set; }
    }
}
