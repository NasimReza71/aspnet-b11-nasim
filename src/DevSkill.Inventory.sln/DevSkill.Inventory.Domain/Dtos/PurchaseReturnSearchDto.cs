using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class PurchaseReturnSearchDto
    {
        public string? ReturnInvoice { get; set; }
        public string? Supplier { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }

}
