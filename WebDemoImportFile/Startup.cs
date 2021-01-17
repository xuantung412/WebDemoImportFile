using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace WebDemoImportFile
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //https://api-crt.cert.havail.sabre.com/v1/lists/supported/shop
            app.UseWebApi(config);
        }
    }
}