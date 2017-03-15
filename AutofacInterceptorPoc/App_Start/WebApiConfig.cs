using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.WebApi;
using AutofacInterceptorPoc.Interceptors;
using AutofacInterceptorPoc.Repositories;

namespace AutofacInterceptorPoc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            SetupIoc(config);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SetupIoc(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ConsoleLoggingInterceptor>().InstancePerDependency();
            builder.RegisterType<RetryInterceptor>().InstancePerDependency();
            builder
                .RegisterType<ValuesRepository>()
                .As<IValuesRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ConsoleLoggingInterceptor))
                .InterceptedBy(typeof(RetryInterceptor))
                .SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
