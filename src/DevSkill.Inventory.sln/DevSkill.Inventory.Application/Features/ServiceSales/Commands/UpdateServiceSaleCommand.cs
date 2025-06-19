using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ServiceSales.Commands
{
    public class UpdateServiceSaleCommand : IRequest
    {
        public Guid Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public string ServiceName { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
    }
}
