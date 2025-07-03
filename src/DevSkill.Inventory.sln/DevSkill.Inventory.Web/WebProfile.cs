using AutoMapper;
using DevSkill.Inventory.Application.Features.Customers.Commands;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Application.Features.Purchases.Commands;
using DevSkill.Inventory.Application.Features.ServiceSales.Commands;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.AccessSetupModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.CustomersModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.DebitVouchersModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.ProductPlusModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.QuotationsModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.ServiceSalesModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.ServicesModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.StaffModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.StaffPaymentModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.SupplierModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.SupplierPaysModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.TransferAccounts;
using DevSkill.Inventory.Web.Areas.Admin.Models.UserModels;

namespace DevSkill.Inventory.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
           
            CreateMap<UpdateProductModel, ProductUpdateCommand>();
            CreateMap<Product, UpdateProductModel>();
            CreateMap<ProductAddCommand, Product>();
            CreateMap<Product, ProductAddCommand>();
            CreateMap<ProductSearchModel, ProductSearchDto>();


            CreateMap<SalesSearchModel, SaleSearchDto>();
            CreateMap<PurchaseReturnSearchModel, PurchaseReturnSearchDto>();

            CreateMap<PurchaseSearchModel, PurchaseSearchDto>();
            CreateMap<PurchaseAddCommand, Purchase>();
            CreateMap<Purchase, PurchaseAddCommand>();
            CreateMap<Purchase,  ProductSearchDto>();
          
            
            CreateMap<Sale, SaleSearchDto>();
            CreateMap<Sale, SaleDto>();
            CreateMap<SalesSearchModel, SaleSearchDto>();
            //CreateMap<Sale, SaleDetailViewModel>();
            //CreateMap<SaleAddViewModel, SaleAddCommand>();
            //CreateMap<SaleUpdateViewModel, SaleUpdateCommand>();
            //CreateMap<Sale, SaleUpdateViewModel>();


            CreateMap<SalesReturnSearchModel, SalesReturnSearchDto>();
            CreateMap<CustomerSearchModel, CustomerSearchDto>();
            CreateMap<Customer, CustomerDetailViewModel>();
            CreateMap<CustomerAddViewModel, CustomerAddCommand>();
            CreateMap<CustomerUpdateViewModel, CustomerUpdateCommand>();
            CreateMap<Customer, CustomerUpdateViewModel>();

            CreateMap<ServiceSaleSearchModel, ServiceSaleSearchDto>();
            CreateMap<ServiceSaleAddViewModel, AddServiceSaleCommand>();
            CreateMap<ServiceSaleUpdateViewModel, UpdateServiceSaleCommand>();
            CreateMap<ServiceSaleDto, ServiceSaleUpdateViewModel>();
            CreateMap<ServiceSaleDto, ServiceSaleDetailViewModel>();


            CreateMap<Quotation, QuotationDto>();
            CreateMap<QuotationSearchModel, QuotationSearchDto>();
            //CreateMap<QuotationAddViewModel, QuotationAddCommand>();
            //CreateMap<QuotationUpdateViewModel, QuotationUpdateCommand>();
            //CreateMap<QuotationDto, QuotationUpdateViewModel>();
            //CreateMap<QuotationDto, QuotationDetailViewModel>();


            //CreateMap<PurchaseReturnSearchModel, PurchaseReturnSearchDto>();

            CreateMap<ServiceSearchModel, ServiceSearchDto>();
            CreateMap<Service, ServiceSearchDto>();

            CreateMap<MoneyReceipt, MoneyReceiptDto>().ReverseMap();


            CreateMap<DebitVoucherSearchModel, DebitVoucherSearchDto>();

            CreateMap<SupplierPaySearchModel, SupplierPaySearchDto>();


            CreateMap<TransferAccountSearchModel, TransferAccountSearchDto>();
            CreateMap<TransferAccount, TransferAccountDto>();
            CreateMap<TransferAccountDto, TransferAccount>();



            CreateMap<BalanceAdjustmentSearchModel, BalanceAdjustmentSearchDto>();
            CreateMap<BalanceAdjustmentSearchDto, BalanceAdjustmentSearchModel>();

           
            CreateMap<BalanceAdjustment, BalanceAdjustmentDto>();
            CreateMap<BalanceAdjustmentDto, BalanceAdjustment>();

            CreateMap<StaffPaymentSearchModel, StaffPaymentSearchDto>();
            CreateMap<StaffPaymentSearchDto, StaffPaymentSearchModel>();
            CreateMap<StaffPayment, StaffPaymentDto>();
            CreateMap<StaffPaymentDto, StaffPayment>();


            CreateMap<SupplierSearchModel, SupplierSearchDto>();
            CreateMap<SupplierSearchDto, SupplierSearchModel>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();



            CreateMap<StaffSearchModel, StaffSearchDto>();
            CreateMap<StaffSearchDto, StaffSearchModel>();
            CreateMap<Staff, StaffDto>();
            CreateMap<StaffDto, Staff>();


            CreateMap<UserSearchModel, UserSearchDto>();
            CreateMap<UserSearchDto, UserSearchModel>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();



            CreateMap<AccessSetupSearchModel, AccessSetupSearchDto>();
            CreateMap<AccessSetupSearchDto, AccessSetupSearchModel>();



            CreateMap<ProductPlusEntity, ProductPlusDto>();
            CreateMap<ProductPlusSearchModel, ProductPlusSearchDto>();

           
            //CreateMap<ProductPlusAddViewModel, ProductPlusAddCommand>();
            //CreateMap<ProductPlusUpdateViewModel, ProductPlusUpdateCommand>();


        }
    }
}
