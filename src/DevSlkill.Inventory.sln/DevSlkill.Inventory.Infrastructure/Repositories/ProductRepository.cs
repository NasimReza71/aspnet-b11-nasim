using DevSlkill.Inventory.Domain.Entities;
using DevSlkill.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSlkill.Inventory.Infrastructure.Repositories
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
    }
}
