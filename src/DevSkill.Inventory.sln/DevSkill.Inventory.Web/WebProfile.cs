using AutoMapper;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.CustomersModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels;
using DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels;
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



            //CreateMap<PurchaseReturnSearchModel, PurchaseReturnSearchDto>();

            //CreateMap<ServiceSearchModel, ServiceSearchDto>();


        }
    }
}
