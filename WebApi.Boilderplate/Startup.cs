using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApi.Boilderplate.Startup))]
namespace WebApi.Boilderplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}