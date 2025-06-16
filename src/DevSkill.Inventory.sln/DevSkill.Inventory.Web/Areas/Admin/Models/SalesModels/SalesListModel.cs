using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels
{
    public class SalesListModel : DataTables
    {
        public SalesSearchModel SearchItem { get; set; } = new();
    }
}
