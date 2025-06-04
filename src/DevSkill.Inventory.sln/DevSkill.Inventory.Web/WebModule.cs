using Autofac;
using System.Reflection;
using DevSkill.Inventory.Web.Models;
using DevSkill.Inventory.Web.Data;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Infrastructure.Repositories;
using DevSkill.Inventory.Domain.Repositories;
using DevSkill.Inventory.Domain.Services;
using DevSkill.Inventory.Application.Services;
using DevSkill.Inventory.Application.Features.Products.Commands;

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



            base.Load(builder); 
        }
    }
}
