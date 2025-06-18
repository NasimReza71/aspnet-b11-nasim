namespace DevSkill.Inventory.Web.Areas.Admin.Models.CustomersModels
{
    public class CustomerAddViewModel
    {
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Status { get; set; }
        public IFormFile CustomerImage { get; set; }
    }
}
