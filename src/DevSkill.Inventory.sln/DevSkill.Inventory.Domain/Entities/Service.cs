using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class Service : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }
}
