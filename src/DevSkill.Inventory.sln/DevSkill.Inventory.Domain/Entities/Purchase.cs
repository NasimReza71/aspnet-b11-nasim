using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class Purchase : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string PurchaseInvoice { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Products { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
    }

}
