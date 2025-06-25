using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.AccessSetupModels
{
    public class AccessSetupListModel : DataTables
    {
        public AccessSetupSearchModel SearchItem { get; set; } = new();
    }
}
