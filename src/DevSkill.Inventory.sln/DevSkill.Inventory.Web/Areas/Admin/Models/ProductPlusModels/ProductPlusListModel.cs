using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.ProductPlusModels
{
    public class ProductPlusListModel : DataTables
    {
        public ProductPlusSearchModel SearchItem { get; set; } = new();
    }
}
