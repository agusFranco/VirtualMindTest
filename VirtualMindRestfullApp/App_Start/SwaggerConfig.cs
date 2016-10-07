using Swashbuckle.Application;
using System.Web.Http;

namespace VirtualMindRestfullApp
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                        {
                            c.SingleApiVersion("v1", "VirtualMind").Description("WebApi for VirtualMind");
                            c.DescribeAllEnumsAsStrings();
                            c.UseFullTypeNameInSchemaIds();
                        })
                 .EnableSwaggerUi(c =>
                    {
                        c.DisableValidator();
                    });
        }
    }
}
