using DevSkill.Inventory.Application.Exceptions;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Services;
using DevSkill.Inventory.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public ProductService(IApplicationUnitOfWork applicationUnitOfWork )
        
        { 
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        public void AddProduct(Product product)
        {
            if (!_applicationUnitOfWork.ProductRepository.IsNameDuplicate(product.Name))
            {
                _applicationUnitOfWork.ProductRepository.Add(product);
                _applicationUnitOfWork.Save();
            }
            else throw new DuplicateProductNameException();
        }

        public void DeleteProduct(Guid id)
        {
            _applicationUnitOfWork.ProductRepository.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public (IList<Product> data, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            return _applicationUnitOfWork.ProductRepository.GetPagedProducts(pageIndex, pageSize, order, search);
        }



        //public List<Product> GetLatestProduct()
        //{
        //    var latestProduct = _applicationUnitOfWork1.ProductRepository.GetLatestProduct();
        //    return latestProduct;
        //}
    }
}
