using Autofac;
using DevSkill.Inventory.Application.Features.Customers.Commands;
using DevSkill.Inventory.Application.Features.Customers.Queries;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Application.Features.PurchaseReturns.Queries;
using DevSkill.Inventory.Application.Features.Purchases.Queries;
using DevSkill.Inventory.Application.Features.Sales.Queries;
using DevSkill.Inventory.Application.Features.SalesReturns.Queries;
using DevSkill.Inventory.Application.Features.ServiceFeatures.Queries;

//using DevSkill.Inventory.Application.Features.Services.Queries;
using DevSkill.Inventory.Application.Services;
using DevSkill.Inventory.Domain;
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
            builder.RegisterType<SaleRepository>().As<ISaleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SalesReturnRepository>().As<ISalesReturnRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseReturnRepository>().As<IPurchaseReturnRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>().InstancePerLifetimeScope();

           // builder.RegisterType<GetCustomersSPQueryHandler>().As<IRequestHandler<GetCustomersSPQuery, (IList<Customer>, int, int)>>().InstancePerLifetimeScope();
            builder.RegisterType<GetPurchasesSPQueryHandler>().As<IRequestHandler<GetPurchasesSPQuery, (IList<Purchase>, int, int)>>().InstancePerLifetimeScope();
            builder.RegisterType<GetSalesSPQueryHandler>().As<IRequestHandler<GetSalesSPQuery, (IList<Sale>, int, int)>>().InstancePerLifetimeScope();
            builder.RegisterType<GetSalesReturnsSPQueryHandler>().As<IRequestHandler<GetSalesReturnsSPQuery, (IList<SalesReturn>, int, int)>>().InstancePerLifetimeScope();
            builder.RegisterType<GetPurchaseReturnsSPQueryHandler>().As<IRequestHandler<GetPurchaseReturnsSPQuery, (IList<PurchaseReturn>, int, int)>>().InstancePerLifetimeScope();
            builder.RegisterType<GetServicesSPQueryHandler>().As<IRequestHandler<GetServicesSPQuery, (IList<Service>, int, int)>>().InstancePerLifetimeScope();

           


            base.Load(builder); 
        }
    }
}
