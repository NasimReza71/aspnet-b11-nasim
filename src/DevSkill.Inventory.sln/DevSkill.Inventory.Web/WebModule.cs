using Autofac;
using DevSkill.Inventory.Application.Features.Customers.Commands;
using DevSkill.Inventory.Application.Features.Customers.Queries;
using DevSkill.Inventory.Application.Features.DebitVouchers.Queries;
using DevSkill.Inventory.Application.Features.MoneyReceipts.Queries;
using DevSkill.Inventory.Application.Features.ProductPlus.Queries;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Application.Features.PurchaseReturns.Queries;
using DevSkill.Inventory.Application.Features.Purchases.Commands;
using DevSkill.Inventory.Application.Features.Purchases.Queries;
using DevSkill.Inventory.Application.Features.Quotations.Queries;
using DevSkill.Inventory.Application.Features.Sales.Queries;
using DevSkill.Inventory.Application.Features.SalesReturns.Queries;
using DevSkill.Inventory.Application.Features.ServiceFeatures.Queries;
using DevSkill.Inventory.Application.Features.ServiceSales.Commands;
using DevSkill.Inventory.Application.Features.ServiceSales.Queries;
using DevSkill.Inventory.Application.Features.SupplierPays.Queries;
using DevSkill.Inventory.Application.Features.TransferAccounts.Queries;
using DevSkill.Inventory.Application.Services;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using DevSkill.Inventory.Domain.Services;
using DevSkill.Inventory.Domain.Utilities;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Infrastructure.Repositories;
using DevSkill.Inventory.Web.Data;
using DevSkill.Inventory.Web.Models;
using MediatR;
using System.Reflection;

namespace DevSkill.Inventory.Web
{
    public class WebModule : Autofac.Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

      

        public WebModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Item>().As<IItem>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();


            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductAddCommand>().AsSelf();


            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GetCustomerByIdQueryHandler>()
               .As<IRequestHandler<GetCustomerByIdQuery, Customer>>()
               .InstancePerLifetimeScope();
            builder.RegisterType<CustomerDeleteCommandHandler>()
                    .As<IRequestHandler<CustomerDeleteCommand>>()
                    .InstancePerLifetimeScope();



            builder.RegisterType<PurchaseRepository>().As<IPurchaseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GetPurchaseByIdQueryHandler>()
                .As<IRequestHandler<GetPurchaseByIdQuery, Purchase>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PurchaseDeleteCommandHandler>()
                .As<IRequestHandler<PurchaseDeleteCommand>>()
                .InstancePerLifetimeScope();





            builder.RegisterType<SaleRepository>().As<ISaleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SaleRepository>().As<ISaleRepository>()
             .InstancePerLifetimeScope();

            //builder.RegisterType<SaleService>().As<ISaleService>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<AddSaleCommand>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<UpdateSaleCommand>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<DeleteSaleCommand>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<GetSalesSPQueryHandler>().As<IRequestHandler<GetSalesSPQuery, (IList<Sale>, int, int)>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetSaleByIdQueryHandler>().As<IRequestHandler<GetSaleByIdQuery, Sale>>()
                .InstancePerLifetimeScope();
            //builder.RegisterType<GetSaleListQueryHandler>().As<IRequestHandler<GetSaleListQuery, IList<Sale>>>()
            //    .InstancePerLifetimeScope();



            builder.RegisterType<SalesReturnRepository>().As<ISalesReturnRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseReturnRepository>().As<IPurchaseReturnRepository>().InstancePerLifetimeScope();


            builder.RegisterType<ServiceRepository>().As<IServiceRepository>().InstancePerLifetimeScope();

            
            
            builder.RegisterType<GetSalesSPQueryHandler>()
                .As<IRequestHandler<GetSalesSPQuery, (IList<Sale>, int, int)>>().InstancePerLifetimeScope();
            builder.RegisterType<GetSalesReturnsSPQueryHandler>()
                .As<IRequestHandler<GetSalesReturnsSPQuery, (IList<SalesReturn>, int, int)>>().InstancePerLifetimeScope();
            builder.RegisterType<GetServicesSPQueryHandler>()
                .As<IRequestHandler<GetServicesSPQuery, (IList<Service>, int, int)>>().InstancePerLifetimeScope();



            builder.RegisterType<AddServiceSaleCommandHandler>()
                 .As<IRequestHandler<AddServiceSaleCommand, Guid>>()
                  .InstancePerLifetimeScope();

            builder.RegisterType<UpdateServiceSaleCommandHandler>()
                .As<IRequestHandler<UpdateServiceSaleCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DeleteServiceSaleCommandHandler>()
                .As<IRequestHandler<DeleteServiceSaleCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetServiceSaleByIdQueryHandler>()
                .As<IRequestHandler<GetServiceSaleByIdQuery, ServiceSaleDto>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetServiceSalesSPQueryHandler>()
                .As<IRequestHandler<GetServiceSalesSPQuery, (IList<ServiceSaleDto>, int, int)>>()
                .InstancePerLifetimeScope();











            builder.RegisterType<QuotationRepository>()
                .As<IQuotationRepository>().InstancePerLifetimeScope();



            
             builder.RegisterType<MoneyReceiptRepository>()
                .As<IMoneyReceiptRepository>()
                .InstancePerLifetimeScope();

             builder.RegisterType<GetMoneyReceiptByIdQueryHandler>()
                 .As<IRequestHandler<GetMoneyReceiptByIdQuery, MoneyReceipt>>() 
                 .InstancePerLifetimeScope();



            builder.RegisterType<DebitVoucherRepository>().As<IDebitVoucherRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GetDebitVouchersSPQueryHandler>().AsSelf();


            builder.RegisterType<SupplierPayRepository>()
         .As<ISupplierPayRepository>()
          .InstancePerLifetimeScope();

            
            builder.RegisterType<GetSupplierPaysSPQueryHandler>()
                   .AsSelf()
                   .InstancePerLifetimeScope();



            builder.RegisterType<TransferAccountRepository>()
       .As<ITransferAccountRepository>()
       .InstancePerLifetimeScope();

            builder.RegisterType<GetTransferAccountsSPQueryHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            builder.RegisterType<BalanceAdjustmentRepository>()
       .As<IBalanceAdjustmentRepository>()
       .InstancePerLifetimeScope();


            builder.RegisterType<StaffPaymentRepository>()
       .As<IStaffPaymentRepository>()
       .InstancePerLifetimeScope();


            builder.RegisterType<SupplierRepository>()
    .As<ISupplierRepository>()
    .InstancePerLifetimeScope();


            builder.RegisterType<StaffRepository>()
    .As<IStaffRepository>()
    .InstancePerLifetimeScope();


            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();



            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SupplierRepository>()
                .As<ISupplierRepository>()
                .InstancePerLifetimeScope();


            builder.RegisterType<StaffRepository>()
                .As<IStaffRepository>()
                .InstancePerLifetimeScope();


            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();


            builder.RegisterType<AccessSetupRepository>()
                .As<IAccessSetupRepository>();


            builder.RegisterType<ProductPlusRepository>().As<IProductPlusRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GetProductPlusByIdQueryHandler>()
                .As<IRequestHandler<GetProductPlusByIdQuery, ProductPlusEntity>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetProductPlusSPQueryHandler>()
                .As<IRequestHandler<GetProductPlusSPQuery, (IList<ProductPlusEntity>, int, int)>>()
                .InstancePerLifetimeScope();

            base.Load(builder); 
        }
    }
}
