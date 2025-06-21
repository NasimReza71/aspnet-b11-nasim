using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.DebitVouchersModels
{
    public class DebitVoucherListModel : DataTables
    {
        public DebitVoucherSearchModel SearchItem { get; set; } = new();
    }
}
