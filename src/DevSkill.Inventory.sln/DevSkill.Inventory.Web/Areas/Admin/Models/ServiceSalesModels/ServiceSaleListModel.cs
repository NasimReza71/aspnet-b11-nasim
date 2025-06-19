using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.ServiceSalesModels
{
    public class ServiceSaleListModel : DataTables
    {
        public ServiceSaleSearchModel SearchItem { get; set; } = new();
    }
}
