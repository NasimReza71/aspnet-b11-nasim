using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class SupplierPay : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Invoice { get; set; }
        public DateTime Date { get; set; }
        public string VoucherType { get; set; } 
        public string Employee { get; set; }   
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }     
    }
}
