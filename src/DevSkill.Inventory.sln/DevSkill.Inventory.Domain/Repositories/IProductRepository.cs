using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        bool IsNameDuplicate(string name, Guid? id = null);
        List<Product> GetLatestProduct();
        (IList<Product> data, int total, int totalDisplay) GetPagedProducts(int pageIndex,
            int pageSize, string? order, DataTablesSearch search);
        void Update(Product product);
       
    }
}
