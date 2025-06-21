using AutoMapper;
using DevSkill.Inventory.Application.Features.Customers.Commands;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Application.Features.ServiceSales.Commands;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.CustomersModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.DebitVouchersModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.QuotationsModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.ServiceSalesModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.ServicesModels;

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

            //CreateMap<ServiceSearchModel, ServiceSearchDto>();

            CreateMap<MoneyReceipt, MoneyReceiptDto>().ReverseMap();


            CreateMap<DebitVoucherSearchModel, DebitVoucherSearchDto>();

        }
    }
}
