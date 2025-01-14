using Autofac;
using System.Reflection;
using DevSkill.Inventory.Web.Models;
 
namespace DevSkill.Inventory.Web
{
    public class WebModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Item>().As<IItem>().InstancePerLifetimeScope();
            base.Load(builder); 
        }
    }
}
