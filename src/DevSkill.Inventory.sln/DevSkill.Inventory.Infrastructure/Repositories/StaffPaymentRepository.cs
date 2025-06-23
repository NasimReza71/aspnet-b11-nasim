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
    public class StaffPaymentRepository : Repository<StaffPayment, Guid>, IStaffPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StaffPaymentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public (IList<StaffPayment> data, int total, int totalDisplay) GetPagedStaffPayments(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(q =>
                    q.Name.Contains(search.Value) ||
                    q.Date.Contains(search.Value) ||
                    q.Salary.ToString().Contains(search.Value) ||
                    q.Attendance.ToString().Contains(search.Value),
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
