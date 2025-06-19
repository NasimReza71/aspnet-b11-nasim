using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get;  }

        Task<(IList<Product> data, int total, int totalDisplay)> GetProductsSP(int pageIndex,
            int pageSize, string? order, ProductSearchDto search);
        public ICustomerRepository CustomerRepository { get; }
        Task<(IList<Customer>, int, int)> GetCustomersSP(int pageIndex, int pageSize, string? order, CustomerSearchDto search);

        IPurchaseRepository PurchaseRepository { get; }

        Task<(IList<Purchase>, int, int)> GetPurchasesSP(int pageIndex, int pageSize, string orderBy, PurchaseSearchDto search);

        ISaleRepository SaleRepository { get; }

        Task<(IList<Sale>, int, int)> GetSalesSP(int pageIndex, int pageSize, string? order, SaleSearchDto search);

        ISalesReturnRepository SalesReturnRepository { get; }

        Task<(IList<SalesReturn>, int, int)> GetSalesReturnsSP(int pageIndex, int pageSize, string? order, SalesReturnSearchDto search);

        IPurchaseReturnRepository PurchaseReturnRepository { get; }
        Task<(IList<PurchaseReturn>, int, int)> GetPurchaseReturnsSP(int pageIndex, int pageSize, string? order, PurchaseReturnSearchDto search);

        IServiceRepository ServiceRepository { get; }
        Task<(IList<Service>, int, int)> GetServicesSP(int pageIndex, int pageSize, string? order, ServiceSearchDto search);

        IServiceSaleRepository ServiceSaleRepository { get; }
        Task<(IList<ServiceSaleDto>, int, int)> GetServiceSalesSP(int pageIndex, int pageSize, string? order, ServiceSaleSearchDto search);



        IQuotationRepository QuotationRepository { get; }

        Task<(IList<Quotation>, int, int)> GetQuotationsSP(int pageIndex, int pageSize, string order, QuotationSearchDto search);

       


    }

}
