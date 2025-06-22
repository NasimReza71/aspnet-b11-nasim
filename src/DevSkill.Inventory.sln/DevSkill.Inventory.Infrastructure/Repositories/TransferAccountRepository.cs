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
    public class TransferAccountRepository : Repository<TransferAccount, Guid>, ITransferAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TransferAccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public (IList<TransferAccount> data, int total, int totalDisplay) GetPagedTransferAccounts(
            int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(q =>
                    q.FromAccount.Contains(search.Value) ||
                    q.ToAccount.Contains(search.Value) ||
                    q.Note.Contains(search.Value),
                    order, null, pageIndex, pageSize, true);
            }
        }
    }
}
