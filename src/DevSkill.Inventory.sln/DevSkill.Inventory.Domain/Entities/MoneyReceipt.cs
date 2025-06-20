using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class MoneyReceipt : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Invoice { get; set; }
        public DateTime Date { get; set; }
        public string VoucherType { get; set; }
        public string Participant { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
