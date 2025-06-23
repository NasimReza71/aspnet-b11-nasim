using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IStaffRepository : IRepository<Staff, Guid>
    {
        int GetStaffCount();
        (IList<Staff> data, int total, int totalDisplay) GetPagedStaffs(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
