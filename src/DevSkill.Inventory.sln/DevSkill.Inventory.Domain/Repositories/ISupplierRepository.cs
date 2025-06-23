using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier, Guid>
    {
        (IList<Supplier> data, int total, int totalDisplay) GetPagedSuppliers(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
