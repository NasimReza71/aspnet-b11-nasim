using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface ISalesReturnRepository : IRepository<SalesReturn, Guid>
    {
        (IList<SalesReturn> data, int total, int totalDisplay) GetPagedSalesReturns(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
