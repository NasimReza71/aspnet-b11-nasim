using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface ISupplierPayRepository : IRepository<SupplierPay, Guid>
    {
        (IList<SupplierPay> data, int total, int totalDisplay) GetPagedSupplierPays(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
