using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IAccessSetupRepository : IRepository<AccessSetup, Guid>
    {
        (IList<AccessSetup> data, int total, int totalDisplay) GetPagedAccessSetups(
            int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
