using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase, Guid>
    {
        bool IsInvoiceDuplicate(string invoice, Guid? id = null);
        (IList<Purchase> data, int total, int totalDisplay) GetPagedPurchases(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }

}
