using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace VirtualMindRestfullApp.App_Start
{
    public class FormattersConfig
    {
        public static void Register(MediaTypeFormatterCollection formatters)
        {
            formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;

            MediaTypeHeaderValue appXmlType = formatters.XmlFormatter.SupportedMediaTypes.First(t => t.MediaType == "application/xml");
            formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
