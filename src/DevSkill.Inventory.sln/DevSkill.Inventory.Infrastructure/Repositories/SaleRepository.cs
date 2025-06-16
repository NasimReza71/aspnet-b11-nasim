using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class SaleRepository : Repository<Sale, Guid>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext context) : base(context) { }

        public (IList<Sale> data, int total, int totalDisplay) GetPagedSales(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);

            return GetDynamic(x =>
                x.InvoiceNumber.Contains(search.Value) ||
                x.CustomerName.Contains(search.Value) ||
                x.CustomerMobile.Contains(search.Value),
                order, null, pageIndex, pageSize, true);
        }
    }
}
