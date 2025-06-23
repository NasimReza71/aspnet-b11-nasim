using DevSkill.Inventory.Domain;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.UserModels
{
    public class UserListModel : DataTables
    {
        public UserSearchModel SearchItem { get; set; } = new();
    }
}
