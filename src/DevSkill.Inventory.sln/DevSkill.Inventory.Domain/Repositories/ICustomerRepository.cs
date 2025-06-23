using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        bool IsMobileDuplicate(string mobile, Guid? id = null);
        bool IsEmailDuplicate(string email, Guid? id = null);
        int GetCustomerCount();

        (IList<Customer> data, int total, int totalDisplay) GetPagedCustomers(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }


}
