using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class DebitVoucher : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime VoucherDate { get; set; }  
        public string VoucherType { get; set; }
        public string CostType { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
