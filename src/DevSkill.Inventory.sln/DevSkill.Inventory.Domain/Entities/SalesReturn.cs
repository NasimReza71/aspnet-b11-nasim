using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class SalesReturn : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string ReturnInvoice { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Mobile { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal Charge { get; set; }
        public decimal Paid { get; set; }
    }
}
