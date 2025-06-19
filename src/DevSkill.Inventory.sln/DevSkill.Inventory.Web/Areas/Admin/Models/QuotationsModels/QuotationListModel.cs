using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.QuotationsModels
{
    public class QuotationListModel : DataTables
    {
        public QuotationSearchModel SearchItem { get; set; } = new();
    }
}
