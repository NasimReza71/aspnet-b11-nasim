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
    public class ServiceSaleRepository : Repository<ServiceSale, Guid>, IServiceSaleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ServiceSaleRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public (IList<ServiceSale> data, int total, int totalDisplay) GetPagedServiceSales(
            int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(x =>
                        x.InvoiceNo.Contains(search.Value) ||
                        x.CustomerName.Contains(search.Value) ||
                        x.ServiceName.Contains(search.Value) ||
                        x.Total.ToString().Contains(search.Value) ||
                        x.Paid.ToString().Contains(search.Value) ||
                        x.Due.ToString().Contains(search.Value),
                    order,
                    null,
                    pageIndex,
                    pageSize,
                    true
                );
            }
        }

        public async Task<ServiceSaleDto?> GetByIdAsDtoAsync(Guid id)
        {
            var entity = await _dbContext.ServiceSales.FindAsync(id);
            if (entity == null) return null;

            return new ServiceSaleDto
            {
                Id = entity.Id,
                InvoiceNo = entity.InvoiceNo,
                Date = entity.Date,
                CustomerId = entity.CustomerId,
                ServiceName = entity.ServiceName,
                Total = entity.Total,
                Paid = entity.Paid,
                Due = entity.Due
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.ServiceSales.FindAsync(id);
            if (entity != null)
            {
                _dbContext.ServiceSales.Remove(entity);
            }
        }
    }
}
