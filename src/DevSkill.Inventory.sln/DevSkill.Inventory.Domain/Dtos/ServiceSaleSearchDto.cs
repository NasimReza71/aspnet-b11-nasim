using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class ServiceSaleSearchDto
    {
        public string? InvoiceNo { get; set; }
        public string? CustomerName { get; set; }
        public string? ServiceName { get; set; }
        public decimal? Total { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Due { get; set; }
    }
}
