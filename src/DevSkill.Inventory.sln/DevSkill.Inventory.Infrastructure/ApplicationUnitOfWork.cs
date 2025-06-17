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
        public ApplicationUnitOfWork(ApplicationDbContext context, IProductRepository productRepository,
             ICustomerRepository customerRepository




            ) : base(context)
        {
            ProductRepository = productRepository;
            CustomerRepository = customerRepository;
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

        public IPurchaseRepository PurchaseRepository { get; private set; }

        public async Task<(IList<Purchase>, int, int)> GetPurchasesSP(int pageIndex, int pageSize, string orderBy, PurchaseSearchDto search)
        {
            var result = await SqlUtility.QueryWithStoredProcedureAsync<Purchase>("GetPurchases",
                new Dictionary<string, object>
                {
            { "PageIndex", pageIndex },
            { "PageSize", pageSize },
            { "OrderBy", orderBy },
            { "PurchaseInvoice", search.PurchaseInvoice },
            { "Name", search.Name },
            { "Products", search.Products },
            { "Total", search.Total },
            { "Paid", search.Paid },
            { "Due", search.Due }
                },
                new Dictionary<string, Type>
                {
            { "Total", typeof(int) },
            { "TotalDisplay", typeof(int) }
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);
        }



        public ISaleRepository SaleRepository { get; private set; }

        public async Task<(IList<Sale>, int, int)> GetSalesSP(int pageIndex, int pageSize, string orderBy, SaleSearchDto search)
        {
            var result = await SqlUtility.QueryWithStoredProcedureAsync<Sale>("GetSales",
                new Dictionary<string, object>
                {
            { "PageIndex", pageIndex },
            { "PageSize", pageSize },
            { "OrderBy", orderBy },
            { "InvoiceNumber", search.InvoiceNumber },
            { "CustomerName", search.CustomerName },
            { "CustomerMobile", search.CustomerMobile },
            { "Total", search.Total },
            { "Paid", search.Paid },
            { "Due", search.Due }
                },
                new Dictionary<string, Type>
                {
            { "Total", typeof(int) },
            { "TotalDisplay", typeof(int) }
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);
        }


        public ISalesReturnRepository SalesReturnRepository { get; }

        public async Task<(IList<SalesReturn>, int, int)> GetSalesReturnsSP(int pageIndex, int pageSize, string? order, SalesReturnSearchDto search)
        {
            var result = await SqlUtility.QueryWithStoredProcedureAsync<SalesReturn>("GetSalesReturns",
                new Dictionary<string, object>
                {
            { "PageIndex", pageIndex },
            { "PageSize", pageSize },
            { "OrderBy", order },
            { "ReturnInvoice", search.ReturnInvoice },
            { "Customer", search.Customer },
            { "Mobile", search.Mobile },
            { "Total", search.Total },
            { "Charge", search.Charge },
            { "Paid", search.Paid },
                },
                new Dictionary<string, Type>
                {
            { "Total", typeof(int) },
            { "TotalDisplay", typeof(int) }
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);
        }


        public IPurchaseReturnRepository PurchaseReturnRepository { get; private set; }

       

        public async Task<(IList<PurchaseReturn>, int, int)> GetPurchaseReturnsSP(int pageIndex, int pageSize, string? order, PurchaseReturnSearchDto search)
        {
            var result = await SqlUtility.QueryWithStoredProcedureAsync<PurchaseReturn>("GetPurchaseReturns",
                new Dictionary<string, object>
                {
                    {"PageIndex", pageIndex},
                    {"PageSize", pageSize},
                    {"OrderBy", order},
                    {"ReturnInvoice", search.ReturnInvoice},
                    {"Supplier", search.Supplier},
                    {"Quantity", search.Quantity},
                    {"TotalPrice", search.TotalPrice}
                },
                new Dictionary<string, Type>
                {
                    {"Total", typeof(int)},
                    {"TotalDisplay", typeof(int)}
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);
        }

        public IServiceRepository ServiceRepository { get; private set; }

        public async Task<(IList<Service>, int, int)> GetServicesSP(int pageIndex, int pageSize, string? orderBy, ServiceSearchDto search)
        {
            var result = await SqlUtility.QueryWithStoredProcedureAsync<Service>("GetServices",
                new Dictionary<string, object>
                {
            { "PageIndex", pageIndex },
            { "PageSize", pageSize },
            { "OrderBy", orderBy },
            { "Code", search.Code },
            { "ServiceName", search.ServiceName },
            { "Price", search.Price },
            { "Details", search.Details }
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
