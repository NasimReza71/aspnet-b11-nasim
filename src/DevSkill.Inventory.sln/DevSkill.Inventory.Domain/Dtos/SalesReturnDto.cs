using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class SalesReturnSearchDto
    {
        public string? ReturnInvoice { get; set; }
        public string? Customer { get; set; }
        public string? Mobile { get; set; }
        public decimal? Total { get; set; }
        public decimal? Charge { get; set; }
        public decimal? Paid { get; set; }
    }
}
