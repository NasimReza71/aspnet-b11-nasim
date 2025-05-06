using DevSlkill.Inventory.Domain;
using DevSlkill.Inventory.Domain.Entities;
using DevSlkill.Inventory.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSlkill.Inventory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork1;
        public ProductService(IApplicationUnitOfWork applicationUnitOfWork )
        
        { 
            _applicationUnitOfWork1 = applicationUnitOfWork;
        }
        public void AddProduct(Product product)
        {
            _applicationUnitOfWork1.ProductRepository.Add(product);
        }
    }
}
