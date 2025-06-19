namespace DevSkill.Inventory.Web.Areas.Admin.Models.ServiceSalesModels
{
    public class ServiceSaleSearchModel
    {
        public string InvoiceNo { get; set; }
        public string ServiceName { get; set; }
        public string CustomerName { get; set; }
        public decimal? Total { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Due { get; set; }
    }
}
