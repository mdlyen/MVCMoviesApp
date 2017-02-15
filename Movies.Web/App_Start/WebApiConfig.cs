using System.Net.Http.Formatting;
using System.Web.Http;
using Movies.Web.Controllers.api;
using Newtonsoft.Json.Serialization;

namespace Movies.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Clear();

            // Add json formatter using camel case instead of Pascal case.
            config.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
            });

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
