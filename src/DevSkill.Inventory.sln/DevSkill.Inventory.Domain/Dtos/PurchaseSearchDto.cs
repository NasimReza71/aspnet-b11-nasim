using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class PurchaseSearchDto
    {
        public string PurchaseInvoice { get; set; }
        public string Name { get; set; }
        public string Products { get; set; }
        public decimal? Total { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Due { get; set; }
    }

}
