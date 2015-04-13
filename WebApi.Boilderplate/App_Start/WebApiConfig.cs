using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Practices.Unity;
using WebApi.Boilderplate.Helpers.DependencyInjection;
using System.Web.Http.ExceptionHandling;
using WebApi.Boilderplate.Helpers.Logging;
using System.Web.Http.Tracing;
using Newtonsoft.Json.Serialization;
using System.Configuration;

namespace WebApi.Boilderplate
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureLogging(config);

            config.MapHttpAttributeRoutes();

            ConfigureContainer(config);

            ConfigureFormatters(config);
        }

        private static void ConfigureLogging(HttpConfiguration config)
        {
            if (ConfigurationManager.GetSection("log4net") == null)     // This is required for integration tests.
                return;

            log4net.Config.XmlConfigurator.Configure();

            config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter), new Log4NetTraceWriter());
            config.Services.Add(typeof(IExceptionLogger), new Log4NetExceptionLogger());
        }

        private static void ConfigureContainer(HttpConfiguration config)
        {
            var container = new UnityContainer();

            // TODO: register any interfaces and their implementations here if you want to use DI.
            // EXAMPLE: see an example of using DI in the BOMController.
            //container.RegisterType<IPayloadMapper, PayloadMapper>(new HierarchicalLifetimeManager());
            //container.RegisterType<IMappingRules, MappingRules>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityResolver(container);
        }
       
        private static void ConfigureFormatters(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
