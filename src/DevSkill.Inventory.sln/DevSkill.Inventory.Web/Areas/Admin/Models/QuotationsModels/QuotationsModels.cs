namespace DevSkill.Inventory.Web.Areas.Admin.Models.QuotationsModels
{
    public class QuotationSearchModel
    {
        public string QuotationNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
