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
    public class SalesReturnRepository : Repository<SalesReturn, Guid>, ISalesReturnRepository
    {
        public SalesReturnRepository(ApplicationDbContext context) : base(context) { }

        public (IList<SalesReturn> data, int total, int totalDisplay) GetPagedSalesReturns(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);

            return GetDynamic(x =>
                x.Customer.Contains(search.Value) ||
                x.Mobile.Contains(search.Value) ||
                x.ReturnInvoice.Contains(search.Value),
                order, null, pageIndex, pageSize, true);
        }
    }
}
