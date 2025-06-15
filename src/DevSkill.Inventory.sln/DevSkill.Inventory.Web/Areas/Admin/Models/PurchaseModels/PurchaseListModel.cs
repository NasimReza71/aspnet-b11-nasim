using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels
{
    public class PurchaseListModel : DataTables
    {
        public PurchaseSearchModel SearchItem { get; set; } = new();
    }
}
