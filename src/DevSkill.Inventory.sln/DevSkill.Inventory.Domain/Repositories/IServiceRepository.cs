using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IServiceRepository : IRepository<Service, Guid>
    {
        bool IsCodeDuplicate(string code, Guid? id = null);
        (IList<Service> data, int total, int totalDisplay) GetPagedServices(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
