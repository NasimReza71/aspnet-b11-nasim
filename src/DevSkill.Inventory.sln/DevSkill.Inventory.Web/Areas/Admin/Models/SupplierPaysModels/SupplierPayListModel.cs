using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.SupplierPaysModels
{
    public class SupplierPayListModel : DataTables
    {
        public SupplierPaySearchModel SearchItem { get; set; } = new();
    }
}
