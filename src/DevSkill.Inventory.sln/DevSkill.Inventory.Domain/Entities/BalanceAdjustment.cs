using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class BalanceAdjustment : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AdjustmentType { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string AccountType { get; set; } 
    }
}
