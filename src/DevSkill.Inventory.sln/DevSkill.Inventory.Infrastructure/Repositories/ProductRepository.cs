using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSkill.Inventory.Infrastructure;
using System.Buffers;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext context) : base(context) 
        
        {
            _dbContext = context;   
        }

  
        public List<Product> GetLatestProduct()
        {
            DateTime date = DateTime.Now.AddDays(-30);
            return _dbContext.Products.Where(x => x.ManufactureDate < date).ToList();


        }

        public bool IsNameDuplicate(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => x.Id != id.Value && x.Name == name) > 0;
            }
            else
                return GetCount(x => x.Name == name) > 0;
        }


        
        public (IList<Product> data, int total, int totalDisplay) GetPagedProducts(int pageIndex, 
            int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            else
            {
                
                return GetDynamic(x => x.Name.Contains(search.Value) ||
                x.Description.Contains(search.Value),
                order, null, pageIndex, pageSize, true);
            }
        }


    }
}
   