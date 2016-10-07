using System.Web.Http;
using VirtualMindRestfullApp.App_Start;

namespace VirtualMindRestfullApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {      
            GlobalConfiguration.Configure(WebApiConfig.Register);            
        }
    }
}
