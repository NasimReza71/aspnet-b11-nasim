namespace DevSkill.Inventory.Web.Areas.Admin.Models.MoneyReceiptsModels
{
    public class MoneyReceiptSearchModel
    {
        public string Invoice { get; set; }
        public string Participant { get; set; }
        public string VoucherType { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
    }
}
