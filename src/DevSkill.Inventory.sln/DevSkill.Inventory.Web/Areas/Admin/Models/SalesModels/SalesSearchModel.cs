namespace DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels
{
    public class SalesSearchModel
    {
        public string? SaleInvoice { get; set; }         
        public string? CustomerName { get; set; }        
        public string? Mobile { get; set; }             
        public decimal? TotalAmount { get; set; }            
        public decimal? Paid { get; set; }             
        public decimal? Due { get; set; }              
        public string? Status { get; set; }              
    }
}
