using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class Quotation : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string QuotationNumber { get; set; }
        public DateTime QuotationDate { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
