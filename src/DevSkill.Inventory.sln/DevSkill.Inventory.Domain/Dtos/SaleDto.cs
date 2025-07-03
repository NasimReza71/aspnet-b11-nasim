using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class SaleDto
    {
        public string SaleNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public decimal SaleAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
