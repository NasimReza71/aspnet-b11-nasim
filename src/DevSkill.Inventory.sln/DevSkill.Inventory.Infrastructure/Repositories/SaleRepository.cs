using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class SaleRepository : Repository<Sale, Guid>, ISaleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

      
        public bool IsInvoiceNumberDuplicate(string invoiceNumber, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => x.Id != id.Value && x.InvoiceNumber == invoiceNumber) > 0;
            }
            else
            {
                return GetCount(x => x.InvoiceNumber == invoiceNumber) > 0;
            }
        }

   
        public (IList<Sale> data, int total, int totalDisplay) GetPagedSales(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(
                    x => x.InvoiceNumber.Contains(search.Value) ||
                         x.CustomerName.Contains(search.Value) ||
                         x.CustomerMobile.Contains(search.Value) ||
                         x.TotalAmount.ToString().Contains(search.Value),
                    order,
                    null,
                    pageIndex,
                    pageSize,
                    true
                );
            }
        }
    }
}
