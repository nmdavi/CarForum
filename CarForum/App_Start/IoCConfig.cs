using Autofac;
using Autofac.Integration.WebApi;
using CarForum.Models.Repository;
using System.Reflection;
using System.Web.Http;

namespace CarForum.App_Start
{
    public class IoCConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}