using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels
{
    public class PurchaseReturnListModel : DataTables
    {
        public PurchaseReturnSearchModel SearchItem { get; set; } = new();
    }
}
