using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IStaffPaymentRepository : IRepository<StaffPayment, Guid>
    {
        (IList<StaffPayment> data, int total, int totalDisplay) GetPagedStaffPayments(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
