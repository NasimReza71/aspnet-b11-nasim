using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels
{
    public class SalesReturnListModel : DataTables
    {
        public SalesReturnSearchModel SearchItem { get; set; } = new();
    }

}
