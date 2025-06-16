using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface ISaleRepository : IRepository<Sale, Guid>
    {
        (IList<Sale> data, int total, int totalDisplay) GetPagedSales(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
