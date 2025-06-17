namespace DevSkill.Inventory.Web.Areas.Admin.Models.CustomersModels
{
    public class CustomerDetailViewModel
    {
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Status { get; set; }
    }
}
