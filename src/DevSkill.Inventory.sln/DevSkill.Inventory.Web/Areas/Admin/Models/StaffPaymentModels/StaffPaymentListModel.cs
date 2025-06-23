using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.StaffPaymentModels
{
    public class StaffPaymentListModel : DataTables
    {
        public StaffPaymentSearchModel SearchItem { get; set; } = new();
    }
}
