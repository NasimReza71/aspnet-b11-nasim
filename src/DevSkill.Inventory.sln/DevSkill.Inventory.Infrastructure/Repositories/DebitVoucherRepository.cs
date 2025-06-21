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
    public class DebitVoucherRepository : Repository<DebitVoucher, Guid>, IDebitVoucherRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DebitVoucherRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public (IList<DebitVoucher> data, int total, int totalDisplay) GetPagedDebitVouchers(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(q =>
                    q.InvoiceNumber.Contains(search.Value) ||
                    q.CostType.Contains(search.Value) ||
                    q.Particulars.Contains(search.Value),
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
