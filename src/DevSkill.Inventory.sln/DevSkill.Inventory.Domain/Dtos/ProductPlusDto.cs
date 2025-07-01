using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class ProductPlusDto
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal MRP { get; set; }
        public decimal WholesalePrice { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
    }
}
