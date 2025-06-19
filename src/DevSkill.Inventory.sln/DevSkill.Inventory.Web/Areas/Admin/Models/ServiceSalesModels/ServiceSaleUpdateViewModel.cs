using System.ComponentModel.DataAnnotations;

namespace DevSkill.Inventory.Web.Areas.Admin.Models.ServiceSalesModels
{
    public class ServiceSaleUpdateViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string InvoiceNo { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal Paid { get; set; }

        [Required]
        public decimal Due { get; set; }
    }
}
