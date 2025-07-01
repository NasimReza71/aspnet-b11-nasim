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
        Task<(IList<Quotation>, int, int)> GetQuotationsSP(int pageIndex, int pageSize, string orderBy, QuotationSearchDto search);



        IMoneyReceiptRepository MoneyReceipts { get; }

        Task<(IList<MoneyReceipt>, int, int)> GetMoneyReceiptsSP(int pageIndex, int pageSize, string order, MoneyReceiptSearchDto search);


        public IDebitVoucherRepository DebitVoucherRepository { get; }

        Task<(IList<DebitVoucher>, int, int)> GetDebitVouchersSP(int pageIndex, int pageSize, string orderBy, DebitVoucherSearchDto search);

        ISupplierPayRepository SupplierPayRepository { get; }

        Task<(IList<SupplierPay>, int, int)> GetSupplierPaysSP(int pageIndex, int pageSize, string orderBy, SupplierPaySearchDto search);

        ITransferAccountRepository TransferAccountRepository { get; }
        Task<(IList<TransferAccount>, int, int)> GetTransferAccountsSP(
            int pageIndex, int pageSize, string orderBy, TransferAccountSearchDto search);

        IBalanceAdjustmentRepository BalanceAdjustmentRepository { get; }
        Task<(IList<BalanceAdjustment>, int, int)> GetBalanceAdjustmentsSP(int pageIndex, int pageSize, string orderBy, BalanceAdjustmentSearchDto search);

        IStaffPaymentRepository StaffPaymentRepository { get; }
        Task<(IList<StaffPayment>, int, int)> GetStaffPaymentsSP(int pageIndex, int pageSize, string orderBy, StaffPaymentSearchDto search);

        ISupplierRepository SupplierRepository { get; }
        Task<(IList<Supplier>, int, int)> GetSuppliersSP(int pageIndex, int pageSize, string orderBy, SupplierSearchDto search);

        IStaffRepository StaffRepository { get; }
        Task<(IList<Staff>, int, int)> GetStaffsSP(int pageIndex, int pageSize, string orderBy, StaffSearchDto search);

        IUserRepository UserRepository { get; }
        Task<(IList<User>, int, int)> GetUsersSP(int pageIndex, int pageSize, string orderBy, UserSearchDto search);

        int GetCustomerCount();
        int GetSupplierCount();
        int GetStaffCount();
        int GetUserCount();

        public IAccessSetupRepository AccessSetupRepository { get; }

        
        Task<(IList<AccessSetup> data, int total, int totalDisplay)> GetAccessSetupsSP(
            int pageIndex, int pageSize, string? order, AccessSetupSearchDto search);

        public IProductPlusRepository ProductPlusRepository { get; } 


        Task<(IList<ProductPlusEntity> data, int total, int totalDisplay)> GetProductPlusSP(
            int pageIndex, int pageSize, string orderBy, ProductPlusSearchDto search);
    }

}
