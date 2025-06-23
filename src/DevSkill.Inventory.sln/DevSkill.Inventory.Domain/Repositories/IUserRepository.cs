using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        int GetUserCount();
        (IList<User> data, int total, int totalDisplay) GetPagedUsers(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
