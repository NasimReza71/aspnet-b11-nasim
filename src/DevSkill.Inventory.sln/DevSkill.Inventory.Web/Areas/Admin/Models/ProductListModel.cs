using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Services;
using System.Data;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Models
{
    public class ProductListModel : DataTables
    {
        public ProductSearchModel SearchItem { get; set; }

    }
}
 