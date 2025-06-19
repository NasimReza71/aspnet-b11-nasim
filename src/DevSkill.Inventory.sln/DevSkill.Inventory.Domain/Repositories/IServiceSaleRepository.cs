using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IServiceSaleRepository : IRepository<ServiceSale, Guid>
    {
        (IList<ServiceSale> data, int total, int totalDisplay) GetPagedServiceSales(
           int pageIndex, int pageSize, string? order, DataTablesSearch search);

        Task<ServiceSaleDto?> GetByIdAsDtoAsync(Guid id);

    }

}
