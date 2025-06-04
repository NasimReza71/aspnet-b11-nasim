using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class ProductSearchDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
    }
}
