using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.BalanceAdjustmentModels
{
    public class BalanceAdjustmentListModel : DataTables
    {
        public BalanceAdjustmentSearchModel SearchItem { get; set; } = new();
    }
}
