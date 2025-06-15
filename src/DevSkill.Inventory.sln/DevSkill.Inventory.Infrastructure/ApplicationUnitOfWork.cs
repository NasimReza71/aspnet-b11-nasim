using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(ApplicationDbContext context, IProductRepository productRepository) : base(context)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; private set; }

        public async Task<(IList<Product> data, int total, int totalDisplay)> GetProductsSP(int pageIndex,
            int pageSize, string? order, ProductSearchDto search)
        {
            var procedureName = "GetProducts";

            var result = await SqlUtility.QueryWithStoredProcedureAsync<Product>(procedureName,
                new Dictionary<string, object>
                {
                    { "PageIndex", pageIndex },
                    { "PageSize", pageSize },
                    { "OrderBy", order },
                    { "Price", search.Price },
                    { "Name", string.IsNullOrEmpty(search.Name) ? null : search.Name },
                    { "Description", string.IsNullOrEmpty(search.Description)? null : search.Description }
                },
                new Dictionary<string, Type>
                {
                    { "Total", typeof(int) },
                    { "TotalDisplay", typeof(int) },
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);

        }

        public ICustomerRepository CustomerRepository { get; private set; }

        public async Task<(IList<Customer>, int, int)> GetCustomersSP(int pageIndex, int pageSize, string orderBy, CustomerSearchDto search)
        {
            var result = await SqlUtility.QueryWithStoredProcedureAsync<Customer>("GetCustomers",
                new Dictionary<string, object>
                {
            { "PageIndex", pageIndex },
            { "PageSize", pageSize },
            { "OrderBy", orderBy },
            { "Id", search.Id },
            { "Name", search.Name },
            { "Mobile", search.Mobile },
            { "Address", search.Address },
            { "CurrentBalance", search.CurrentBalance }
                },
                new Dictionary<string, Type>
                {
            { "Total", typeof(int) },
            { "TotalDisplay", typeof(int) }
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);
        }


    }
}
