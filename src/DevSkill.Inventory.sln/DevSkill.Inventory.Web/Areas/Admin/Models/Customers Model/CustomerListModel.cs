using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.Customers_Model
{
    public class CustomerListModel : DataTables
    {
        public CustomerSearchModel SearchItem { get; set; } = new();
    }
}
