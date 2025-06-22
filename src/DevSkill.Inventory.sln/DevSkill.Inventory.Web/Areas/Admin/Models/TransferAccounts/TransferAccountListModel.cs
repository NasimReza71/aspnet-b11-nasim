using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.TransferAccounts
{
    public class TransferAccountListModel : DataTables
    {
        public TransferAccountSearchModel SearchItem { get; set; } = new();
    }
}
