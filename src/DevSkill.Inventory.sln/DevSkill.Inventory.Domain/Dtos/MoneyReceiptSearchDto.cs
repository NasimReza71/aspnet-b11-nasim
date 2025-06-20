using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class MoneyReceiptSearchDto
    {
        public string Invoice { get; set; }
        public string Participant { get; set; }
        public string VoucherType { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
    }
}
