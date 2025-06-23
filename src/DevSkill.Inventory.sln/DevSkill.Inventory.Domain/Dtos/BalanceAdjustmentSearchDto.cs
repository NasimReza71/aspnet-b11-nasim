using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class BalanceAdjustmentSearchDto
    {
        public string AdjustmentType { get; set; }
        public string AccountType { get; set; }
    }
}
