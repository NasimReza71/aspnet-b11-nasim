using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.SupplierModels
{
    public class SupplierListModel : DataTables
    {
        public SupplierSearchModel SearchItem { get; set; } = new();
    }
}
