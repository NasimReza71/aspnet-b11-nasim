using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Entities
{
    public class ProductPlusEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal MRP { get; set; }
        public decimal WholesalePrice { get; set; }
        public int StockQuantity { get; set; }
        public int LowStockThreshold { get; set; }
        public int DamageStock { get; set; }
        public bool IsActive => StockQuantity > 0;
        public string ImagePath { get; set; }
    }
}
