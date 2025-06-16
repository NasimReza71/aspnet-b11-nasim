namespace DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels
{
    public class PurchaseReturnSearchModel
    {
        public string? ReturnInvoice { get; set; }
        public string? Supplier { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
