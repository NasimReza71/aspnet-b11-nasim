using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IPurchaseReturnRepository : IRepository<PurchaseReturn, Guid>
    {
        (IList<PurchaseReturn> data, int total, int totalDisplay) GetPagedPurchaseReturns(int pageIndex, int pageSize, string? order, DataTablesSearch search);

    }
}
