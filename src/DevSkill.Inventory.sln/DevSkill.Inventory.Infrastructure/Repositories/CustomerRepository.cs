using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public bool IsEmailDuplicate(string email, Guid? id = null)
        {
            if (id.HasValue)
                return GetCount(x => x.Id != id.Value && x.Email == email) > 0;
            else
                return GetCount(x => x.Email == email) > 0;
        }
        public bool IsMobileDuplicate(string mobile, Guid? id = null)
        {
            if (id.HasValue)
                return GetCount(x => x.Id != id.Value && x.Mobile == mobile) > 0;
            else
                return GetCount(x => x.Mobile == mobile) > 0;
        }

        public int GetCustomerCount()
        {
            return _dbContext.Customers.Count();
        }

        public (IList<Customer> data, int total, int totalDisplay) GetPagedCustomers(
            int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(x =>
                        x.Name.Contains(search.Value) ||
                        x.Mobile.Contains(search.Value) ||
                        x.Address.Contains(search.Value) ||
                        x.Email.Contains(search.Value) ||
                        x.CurrentBalance.ToString().Contains(search.Value),
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
