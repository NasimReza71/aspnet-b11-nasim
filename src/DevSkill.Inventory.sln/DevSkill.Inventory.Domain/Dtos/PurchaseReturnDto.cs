using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class PurchaseReturnDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string ReturnInvoice { get; set; }
        public string Supplier { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
