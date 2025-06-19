namespace DevSkill.Inventory.Web.Areas.Admin.Models.ServiceSalesModels
{
    public class ServiceSaleDetailViewModel
    {
        public Guid Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public string ServiceName { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
    }
}
