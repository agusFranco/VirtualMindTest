using System.Web.Http;
using VirtualMindRestfullApp.App_Start;

namespace VirtualMindRestfullApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            FormattersConfig.Register(config.Formatters);
            UnityConfig.RegisterComponents();
            SwaggerConfig.Register(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
