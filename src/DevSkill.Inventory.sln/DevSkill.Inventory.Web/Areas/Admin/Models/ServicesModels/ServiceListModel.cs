using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Web.Areas.Admin.Models.ServicesModels;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.ServicesModels
{
    public class ServiceListModel : DataTables
    {
        public ServiceSearchModel SearchItem { get; set; } = new();
    }
}
