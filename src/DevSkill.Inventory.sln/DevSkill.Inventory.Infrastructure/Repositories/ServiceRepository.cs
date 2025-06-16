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
    public class ServiceRepository : Repository<Service, Guid>, IServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool IsCodeDuplicate(string code, Guid? id = null)
        {
            if (id.HasValue)
                return GetCount(x => x.Id != id.Value && x.Code == code) > 0;
            else
                return GetCount(x => x.Code == code) > 0;
        }

        public (IList<Service> data, int total, int totalDisplay) GetPagedServices(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            else
                return GetDynamic(x => x.ServiceName.Contains(search.Value) ||
                                      x.Code.Contains(search.Value) ||
                                      x.Details.Contains(search.Value),
                                   order, null, pageIndex, pageSize, true);
        }
    }
}
