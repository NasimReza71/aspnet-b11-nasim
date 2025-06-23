using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.StaffModels
{
    public class StaffListModel : DataTables
    {
        public StaffSearchModel SearchItem { get; set; } = new();
    }
}
