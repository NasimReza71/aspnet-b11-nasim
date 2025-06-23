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
    public class BalanceAdjustmentRepository : Repository<BalanceAdjustment, Guid>, IBalanceAdjustmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BalanceAdjustmentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public (IList<BalanceAdjustment> data, int total, int totalDisplay) GetPagedBalanceAdjustments(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(q =>
                    q.AdjustmentType.Contains(search.Value) ||
                    q.AccountType.Contains(search.Value),
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
