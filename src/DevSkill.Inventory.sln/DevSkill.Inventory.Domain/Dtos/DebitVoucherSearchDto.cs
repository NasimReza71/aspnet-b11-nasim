using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class DebitVoucherSearchDto
    {
        public string InvoiceNumber { get; set; }
        public string CostType { get; set; }
        public string Particulars { get; set; }
        public string Status { get; set; }
    }
}
