using System.ComponentModel.DataAnnotations;

namespace DevSkill.Inventory.Web.Areas.Admin.Models
{
    public class UpdateProductModel
    {
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime? ManufactureDate { get; set; }
    }
}
