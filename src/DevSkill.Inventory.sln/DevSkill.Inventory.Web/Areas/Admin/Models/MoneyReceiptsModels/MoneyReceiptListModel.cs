using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.MoneyReceiptsModels
{
    public class MoneyReceiptListModel : DataTables
    {
        public MoneyReceiptSearchModel SearchItem { get; set; } = new();
    }
}
