using Microsoft.Owin;
using Owin;
using ThucPham.Data.Infrastructure;
using ThucPham.Data;
using Microsoft.AspNet.Identity;
using ThucPham.Data.Repositories;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Reflection;
using ThucPham.Model.Models;
using Autofac;
using System.Web;
using Microsoft.Owin.Security.DataProtection;
using ThucPham.Service;

[assembly: OwinStartup(typeof(WebAPI.App_Start.Startup))]

namespace WebAPI.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            configAutofac(app);
            ConfigureAuth(app);
        }

        private void configAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();


            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Register your web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<WebApiDbContext>().AsSelf().InstancePerRequest();


            //Asp.net Identity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();


            //Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Services

            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }
    }
}

