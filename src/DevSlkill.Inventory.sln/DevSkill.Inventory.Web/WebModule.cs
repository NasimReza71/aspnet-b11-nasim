using Autofac;
using System.Reflection;
using DevSkill.Inventory.Web.Models;
using DevSkill.Inventory.Web.Data;
using DevSlkill.Inventory.Domain;
using DevSlkill.Inventory.Infrastructure;
using DevSlkill.Inventory.Infrastructure.Repositories;
using DevSlkill.Inventory.Domain.Repositories;
using DevSlkill.Inventory.Domain.Services;
using DevSlkill.Inventory.Application.Services;

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



            base.Load(builder); 
        }
    }
}
