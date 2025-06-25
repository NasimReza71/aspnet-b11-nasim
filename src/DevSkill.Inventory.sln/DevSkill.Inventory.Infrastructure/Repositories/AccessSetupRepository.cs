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
    public class AccessSetupRepository : Repository<AccessSetup, Guid>, IAccessSetupRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AccessSetupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public (IList<AccessSetup> data, int total, int totalDisplay) GetPagedAccessSetups(
            int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(q =>
                    q.CompID.Contains(search.Value) ||
                    q.UserType.Contains(search.Value) ||
                    q.Status.Contains(search.Value),
                    order, null, pageIndex, pageSize, true);
            }
        }
    }
}
