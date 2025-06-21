using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class SupplierPaySearchDto
    {
        public string Invoice { get; set; }
        public string Employee { get; set; }
        public string Particulars { get; set; }
        public string Status { get; set; }
    }
}
