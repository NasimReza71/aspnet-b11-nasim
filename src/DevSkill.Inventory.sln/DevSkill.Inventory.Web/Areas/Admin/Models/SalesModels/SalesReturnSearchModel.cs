namespace DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels
{
    public class SalesReturnSearchModel
    {
        public string? ReturnInvoice { get; set; }
        public string? Customer { get; set; }
        public string? Mobile { get; set; }   
        public decimal? Total { get; set; }
        public decimal? Charge { get; set; }
        public decimal? Paid { get; set; }
    }

}
