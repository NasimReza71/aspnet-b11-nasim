using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IDebitVoucherRepository : IRepository<DebitVoucher, Guid>
    {
        (IList<DebitVoucher> data, int total, int totalDisplay) GetPagedDebitVouchers(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
