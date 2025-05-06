namespace DevSkill.Inventory.Web.Areas.Admin.Models
{
    public class AddProductModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public DateTime? ManufactureDate { get; set; }
    }
}
